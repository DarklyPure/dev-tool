using System.Text;

namespace Pure.Library.Extensions;

public static class StringBuilderExtensions
{
    #region Variables
    private static Random _random = new();
    private static string _alphabet = "abcdefghijklmnopqrstuvwxyz";
    #endregion

    #region Randomiser Methods
    public static Uri GenerateRandomUri(this StringBuilder stringBuilder, bool useHttps = true)
    {
        Uri? result;
        int loops = 0;

        if (useHttps)
        {
            stringBuilder.Append("https://");
        }
        else
        {
            stringBuilder.Append("http://");
        }

        while (loops < 3)
        {
            stringBuilder.Append(stringBuilder.GenerateRandomStringOfLetters(10));
            stringBuilder.Append("/");
        }

        result = new Uri(stringBuilder.ToString());
        stringBuilder.Clear();
        return result;
    }

    /// <summary>
    /// Returns a string of random letters, providing a pseudo word.
    /// </summary>
    /// <param name="length">The length of the psuedo word</param>
    /// <param name="propercase">Specifies that it must be proper case</param>
    /// <returns>A psuedo word</returns>
    public static string GenerateRandomPseudoWord(this StringBuilder stringBuilder, int length, bool propercase = true)
    {
        string? result;

        int i = 0;

        while (i < length)
        {
            string letter = _alphabet.Substring(_random.Next(1, 26), 1);

            if (i == 0 && propercase)
            {
                stringBuilder.Append(letter.ToUpper());
            }
            else
            {
                stringBuilder.Append(letter);
            }

            i++;
        }

        result = stringBuilder.ToString();

        stringBuilder.Clear();
        return result;
    }

    /// <summary>
    /// Returns a string containing random pseudo words.
    /// </summary>
    /// <param name="wordCount">The number of words for the sentence.</param>
    /// <param name="maxLetterCount">The maximum number of letters, for the words.</param>
    /// <returns>A psuedo sentence.</returns>
    public static string GenerateRandomPseudoSentence(this StringBuilder stringBuilder, int wordCount = 6, int maxLetterCount = 10)
    {
        string? result;
        int i = 0;

        while (i < wordCount)
        {
            int wordLength = _random.Next(1, maxLetterCount);
            bool properCase = _random.Next(1, 2) == 1;

            string word = stringBuilder.GenerateRandomPseudoWord(wordLength, properCase);

            stringBuilder.Append(word);

            if (i < wordCount - 1) { stringBuilder.Append(" "); }
            i++;
        }

        result = stringBuilder.ToString();
        stringBuilder.Clear();

        return result;
    }

    public static string GenerateRandomPageOfPseudoSentences(this StringBuilder stringBuilder, int lineCount)
    {
        string? result;
        int counter = 0;

        while (counter < lineCount)
        {
            int wordCount = _random.Next(1, 20);
            int letterCount = _random.Next(1, 20);

            stringBuilder.AppendLine(stringBuilder.GenerateRandomPseudoSentence(wordCount, letterCount));
            counter++;
        }

        result = stringBuilder.ToString();
        stringBuilder.Clear();

        return result;
    }

    public static string GenerateRandomStringOfLetters(this StringBuilder stringBuilder, int length)
    {
        string? result;

        int i = 0;

        while (i < length)
        {
            string letter = _alphabet.Substring(_random.Next(1, 26), 1);

            stringBuilder.Append(letter);

            i++;
        }

        result = stringBuilder.ToString();
        stringBuilder.Clear();

        return result;
    }

    public static string GenerateRandomJson(this StringBuilder stringBuilder)
    {
        string? result;

        stringBuilder.Append('{');
        // Generate string
        stringBuilder.Append(@$"""{new StringBuilder().GenerateRandomPseudoWord(10, true)}"": ");
        stringBuilder.Append(@$"""{new StringBuilder().GenerateRandomPseudoWord(10, true)}"", ");

        // Generate int
        stringBuilder.Append(@$"""{new StringBuilder().GenerateRandomPseudoWord(10, true)}"": ");
        stringBuilder.Append($"{_random.Next(0, 1000000)}, ");

        // Generate decimal
        stringBuilder.Append(@$"""{new StringBuilder().GenerateRandomPseudoWord(10, true)}"": ");
        stringBuilder.Append($"{_random.Next(0, 1000000) / 100m}, ");

        // Generate date
        stringBuilder.Append(@$"""{new StringBuilder().GenerateRandomPseudoWord(10, true)}"": ");
        stringBuilder.Append($"{DateTime.Now.GenerateRandomDateTime()}, ");

        stringBuilder.Append('}');

        result = stringBuilder.ToString();
        stringBuilder.Clear();

        return result;
    }
    #endregion
}