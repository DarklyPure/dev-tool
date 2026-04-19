namespace Pure.Library.Extensions
{
    public static class DirectoryInfoExtensions
    {
        private static List<string> _directories = [];
        /// <summary>
        /// Recurses through the <see cref="DirectoryInfo"/> instance, getting a list of all sub directories
        /// </summary>
        /// <param name="directoryInfo">THe <see cref="DirectoryInfo"/></param>
        /// <returns>A collection of all directories</returns>
        public static List<string> GetDirectoryTree(this DirectoryInfo directoryInfo)
        {
            _directories.Add(directoryInfo.FullName);

            foreach (DirectoryInfo subDirectoryInfo in directoryInfo.EnumerateDirectories())
            {
                GetDirectoryTree(subDirectoryInfo);
            }

            return _directories;
        }

        public static string[] AllFilesOfType(this DirectoryInfo directoryInfo, string[] fileTypes, List<string>? foundFiles = null)
        {
            foundFiles ??= [];

            foreach (FileInfo file in directoryInfo.GetFiles().Where(f => fileTypes.Contains(f.Extension)))
            {
                foundFiles.Add(file.FullName);
            }
            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                directory.AllFilesOfType(fileTypes, foundFiles);
            }
            return [.. foundFiles];
        }
    }
}
