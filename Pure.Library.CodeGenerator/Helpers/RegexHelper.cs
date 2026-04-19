using Pure.Library.CodeGenerator.Extensions;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Pure.Library.CodeGenerator.Helpers;

public partial class RegexHelper
{
    #region Public Property Implementations
    public static Regex EmailRegex => EmailExpression();
    public static Regex FirstNameRegex => AlphabeticCharactersExpression();
    public static Regex SplitOnCapitalLetterRegex => SplitOnCapitalLetterExpression();
    #endregion

    #region Compiled Regex
    /// <summary>
    /// Finds alphabetical characters wrapped in square brackets.
    /// </summary>
    /// <example>
    /// E.g.:
    /// [abc]
    /// [XYZ]
    /// [Pqr] etc.
    /// </example>
    /// <returns>A <see cref="Regex"/> instance.</returns>
    [GeneratedRegex(@"^\[[a-zA-Z]*\]", RegexOptions.IgnoreCase)]
    protected static partial Regex WrapperSquareBracketsExpression();

    /// <summary>
    /// Finds alphabetical characters wrapped in pipes.
    /// </summary>
    /// <example>
    /// E.g.:
    /// |abc|
    /// |XYZ|
    /// |Pqr| etc.
    /// </example>
    /// <returns>A <see cref="Regex"/> instance.</returns>
    [GeneratedRegex(@"\|[a-zA-Z]*\|")]
    protected static partial Regex WrapperPipeExpression();

    [GeneratedRegex(@"\[[a-zA-Z]*\]", RegexOptions.IgnoreCase)]
    protected static partial Regex DynamicTextSquareBracketsExpression();

    /// <summary>
    /// Finds alphabetical characters only.
    /// </summary>
    /// <example>
    /// E.g.:
    /// abcde
    /// XYZ
    /// pQr
    /// </example>
    /// <returns>A <see cref="Regex"/> instance.</returns>
    [GeneratedRegex("[a-zA-Z]*")]
    protected static partial Regex AlphabeticCharactersExpression();

    /// <summary>
    /// Finds any consequetive numbers.
    /// </summary>
    /// <example>
    /// E.g.:
    /// 123
    /// 3245
    /// </example>
    /// <returns>A <see cref="Regex"/> instance.</returns>
    [GeneratedRegex("[0-9]*")]
    protected static partial Regex NumbersOnlyExpression();

    [GeneratedRegex(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])")]
    protected static partial Regex EmailExpression();

    [GeneratedRegex(@"(?<=\[\[)(.*?)(?=\]\])")]
    protected static partial Regex DoubleSqueareBracketWrappedExpression();

    [GeneratedRegex(@"(?=[A-Z])")]
    protected static partial Regex SplitOnCapitalLetterExpression();
    #endregion


    /// <summary>
    /// Parses the input to return just alphabetical characters
    /// </summary>
    /// <param name="text">The text to parse</param>
    /// <returns>A string containing only alphabetical characters or an empty string if no match is found</returns>
    public static string ParseForAplphabeticalChars(string text)
    {
        StringBuilder stringBuilder = new();

        Span<Match> span = CollectionsMarshal.AsSpan(AlphabeticCharactersExpression().Matches(text).ToList());

        for (int i = 0; i < span.Length; i++)
        {
            string value = span[i].Value;

            if (!string.IsNullOrEmpty(value))
            {
                stringBuilder.Append(value);
            }
        }
        return stringBuilder.ToString();
    }
    /// <summary>
    /// Parses the passed text for the existence of a square bracket wrapper []
    /// </summary>
    /// <param name="text">The text containing dynamic content as wrapped by two square brackets</param>
    /// <returns>A <see cref="Tuple{T1, T2}"/> containing the dynamic text and the orginal text with the dynamic text removed</returns>
    /// <example>
    /// ParseSquareBracketWrapper("[MyDocuments]Folder/Folder2]");
    /// returns:
    /// Item1: MyDocuments
    /// Item2: Folder/Folder2
    /// </example>
    public static Tuple<string, string>? ParseSquareBracketWrapper(string text)
    {
        string wrappedText = WrapperSquareBracketsExpression().Match(text).Value;

        if (!string.IsNullOrEmpty(wrappedText))
        {
            Tuple<string, string> tuple = new(
                    wrappedText.Substring(1, wrappedText.Length - 2),
                    text.Replace(wrappedText, string.Empty)
                );
            return tuple;
        }
        return null;
    }
    /// <summary>
    /// Reconstructs the passed text into a special folder based fully qualified path
    /// </summary>
    /// <param name="text">The text containing a special folder path wrapped within [] brackets</param>
    /// <returns></returns>
    public static string ParseProjectDirectory(string text, string projectName)
    {
        Tuple<string, string>? parsedText = ParseSquareBracketWrapper(text);

        if (parsedText != null)
        {
            // Get the special folder enum
            Environment.SpecialFolder specialFoldeEnum = Enum.Parse<Environment.SpecialFolder>(parsedText.Item1);

            // Get the special folder path
            string specialFolderPath = Environment.GetFolderPath(specialFoldeEnum);

            // Build the path
            return Path.Combine(specialFolderPath, projectName, parsedText.Item2);
        }

        return string.Empty;
    }
    public static int ParseForNumbers(string text)
    {
        StringBuilder stringBuilder = new();

        Span<Match> span = CollectionsMarshal.AsSpan(NumbersOnlyExpression().Matches(text).ToList());

        for (int i = 0; i < span.Length; i++)
        {
            string value = span[i].Value;

            if (!string.IsNullOrEmpty(value))
            {
                stringBuilder.Append(value);
            }
        }

        return stringBuilder.ToString().ToInt();
    }
    public static Regex DynamicTextSquareBrackets => DynamicTextSquareBracketsExpression();

    public static Regex DoubleSquareBracketWrappedRegex => DoubleSqueareBracketWrappedExpression();
}
