using System.Text;

namespace Pure.Library.Extensions
{
    public static class FileExtensions
    {
        /// <summary>
        /// Imports the file as specified by the <see cref="FileInfo"/> instance
        /// </summary>
        /// <param name="fileInfo">The <see cref="FileInfo"/> instance</param>
        /// <returns>A <see cref="byte"/> array containing the contents of the file</returns>
        public static byte[] ImportToByteArray(this FileInfo fileInfo)
        {
            using FileStream fileStream = new(fileInfo.FullName, FileMode.Open, FileAccess.Read);
            using BinaryReader binaryReader = new(fileStream);
            byte[] fileBytes = binaryReader.ReadBytes((int)fileStream.Length);
            fileStream.Flush();

            binaryReader.Close();

            fileStream.Close();

            return fileBytes;
        }
        /// <summary>
        /// Imports the file as specified by the <see cref="FileInfo"/> instance
        /// </summary>
        /// <param name="fileInfo">The <see cref="FileInfo"/> instance</param>
        /// <returns>A string containing the contents of the file</returns>
        /// <summary>
        /// Reads the contents of the <see cref="FileInfo"/> file into a string
        /// </summary>
        /// <param name="fileInfo">The <see cref="FileInfo"/> instance</param>
        /// <returns>A string contining the contents of the <see cref="FileInfo"/> instance</returns>
        public static async Task<string> ImportToStringAsync(this FileInfo fileInfo, CancellationToken cancellationToken)
        {
            StringBuilder stringBuilder = new();
            using StreamReader streamReader = new(fileInfo.FullName);

            while (!streamReader.EndOfStream)
            {
                stringBuilder.AppendLine(await streamReader.ReadLineAsync(cancellationToken));
            }

            streamReader.Close();
            streamReader.Dispose();

            return stringBuilder.ToString();
        }
        public static string ImportToString(this FileInfo fileInfo)
        {
            StringBuilder stringBuilder = new();
            using StreamReader streamReader = new(fileInfo.FullName);

            long length = streamReader.BaseStream.Length;

            while (!streamReader.EndOfStream)
            {
                stringBuilder.AppendLine(streamReader.ReadLine());
            }
            streamReader.Close();
            streamReader.Dispose();

            return stringBuilder.ToString();
        }
    }
}
