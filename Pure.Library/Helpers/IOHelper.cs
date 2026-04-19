using System.Text;

namespace Pure.Library.Helpers;

public static class IOHelper
{
    /// <summary>
    /// Writes the string passed to the file at the path specified.
    /// </summary>
    /// <param name="path">The path to the fully qualified</param>
    /// <param name="content"></param>
    /// <returns>True if successful.</returns>
    public static bool WriteToFile(string path, string content)
    {
        bool success;

        try
        {
            using StreamWriter writer = new(path);

            writer.Write(content);
            writer.Flush();

            success = true;
        }
        catch (Exception) { throw; }

        return success;
    }

    /// <summary>
	/// Reads the contents of the file at the path specified into a string.
	/// </summary>
	/// <param name="path">The fully qualified path to the file to read.</param>
	/// <returns>A string containing the contents of the file.</returns>
    public static string ReadFromFile(string path)
    {
        StringBuilder builder = new();

        try
        {
            using FileStream fileStream = new(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 1024 * 64, useAsync: false);
            using StreamReader streamReader = new(fileStream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, bufferSize: 1024 * 64);

            string? line;

            while ((line = streamReader.ReadLine()) != null)
            {
                builder.AppendLine(line);
            }

            streamReader.Close();
        }
        catch (Exception) { throw; }

        return builder.ToString();
    }
}
