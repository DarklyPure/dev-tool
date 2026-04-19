namespace Pure.Library.Services;

public sealed class DirectoryManagementService
{
    /// <summary>
    /// Gets the <see cref="DirectoryInfo"/> for the path specified, creating it if it does not exist.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns></returns>
    public async Task<Result<DirectoryInfo, Exception>> GetOrCreateDirectoryAsync(string path)
    {
        Result<DirectoryInfo, Exception> result;
        try
        {
            DirectoryInfo directory = new(path);

            if (!directory.Exists)
            {
                await Task.Run(() => directory.Create());
            }
            result = directory;
        }
        catch (Exception ex) { result = ex; }

        return result;
    }

    /// <summary>
    /// Gets the <see cref="DirectoryInfo"/> for the path specified, creating it if it does not exist.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns></returns>
    public Result<DirectoryInfo, Exception> GetOrCreateDirectory(string path)
    {
        Result<DirectoryInfo, Exception> result;
        try
        {
            DirectoryInfo directory = new(path);

            if (!directory.Exists)
            {
                directory.Create();
            }
            result = directory;
        }
        catch (Exception ex) { result = ex; }

        return result;
    }

    /// <summary>
    /// Gets the <see cref="DirectoryInfo"/> information for the paths specified, creating them if they do not exist.
    /// </summary>
    /// <param name="paths">The paths.</param>
    /// <returns>A <see cref="Result"/> collection instance.</returns>
    public async Task<Result<DirectoryInfo, Exception>[]> GetOrCreateDirectoriesAsync(string[] paths)
    {
        List<Result<DirectoryInfo, Exception>> results = [];
        int i = 0;
        while (i < paths.Length)
        {
            results.Add(await GetOrCreateDirectoryAsync(paths[i++]));
        }

        return results.ToArray();
    }

    /// <summary>
    /// Gets the <see cref="DirectoryInfo"/> information for the paths specified, creating them if they do not exist.
    /// </summary>
    /// <param name="paths">The paths.</param>
    /// <returns>A <see cref="Result"/> collection instance.</returns>
    public Result<DirectoryInfo, Exception>[] GetOrCreateDirectories(string[] paths)
    {
        List<Result<DirectoryInfo, Exception>> results = [];
        int i = 0;
        while (i < paths.Length)
        {
            results.Add(GetOrCreateDirectory(paths[i++]));
        }

        return results.ToArray();
    }
}
