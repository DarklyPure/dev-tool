namespace Pure.Library.Extensions
{
    public static class ByteArrayExtensions
    {
        public static async Task<bool> WriteToFileAsync(this byte[] byteArray, string destinationPath, string nameAndExtension)
        {
            if (!Directory.Exists(destinationPath))
            {
                return false;
            }

            using FileStream fileStream = new(Path.Combine(destinationPath, nameAndExtension), FileMode.Create, FileAccess.Write);

            await fileStream.WriteAsync(byteArray, 0, byteArray.Length);

            await fileStream.FlushAsync();

            fileStream.Close();

            return true;
        }
        public static bool WriteToFile(this byte[] byteArray, string destinationPath, string nameAndExtension)
        {
            if (!Directory.Exists(destinationPath))
            {
                return false;
            }

            using FileStream fileStream = new(Path.Combine(destinationPath, nameAndExtension), FileMode.Create, FileAccess.Write);

            fileStream.Write(byteArray, 0, byteArray.Length);

            fileStream.Flush();

            fileStream.Close();

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static Stream ToStream(this byte[] byteArray)
        {
            MemoryStream memoryStream = new();
            memoryStream.Write(byteArray, 0, byteArray.Length);

            return memoryStream;
        }
        public static async Task<Stream> ToStreamAsync(this byte[] byteArray)
        {
            MemoryStream memoryStream = new();
            await memoryStream.WriteAsync(byteArray, 0, byteArray.Length);

            return memoryStream;
        }
    }
}
