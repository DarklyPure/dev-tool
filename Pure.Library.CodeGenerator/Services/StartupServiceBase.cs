using Pure.Library.Interfaces;
using Pure.Library.Services;

namespace Pure.Library.CodeGenerator.Services;

/// <summary>
/// Service managing the startup housekeeping for any app.
/// </summary>
/// <param name="appSettings">An <see cref="IAppSettings"/> instance.</param>
/// <remarks>
/// As a minimum, creates a folder in MyDocuments with a log directory there.
/// This Application folder will be named after your Application.
/// </remarks>
public abstract class StartUpServiceBase(IAppSettings appSettings, DirectoryManagementService directoryManagementService)
{
    protected IAppSettings _appSettings = appSettings;
    protected bool _environmentIsSetup;
    protected DirectoryManagementService _directoryManagementService = directoryManagementService;
    /// <summary>
    /// Creates the required basic environment where it doesn't exist.
    /// It also updates the passed <see cref="IAppSettings"/> instance with the details.
    /// </summary>
    /// <param name="settings">The <see cref="IAppSettings"/> instance.</param>
    /// <returns>The updated <see cref="IAppSettings"/> instance.</returns>
    public virtual IAppSettings RefreshEnvironment()
    {
        string rootPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _appSettings.ApplicationName);

        Library.Result<DirectoryInfo, Exception> result = _directoryManagementService.GetOrCreateDirectory(rootPath);

        if (result.IsSuccess) { _appSettings.ApplicationRootDirectory = rootPath; }

        return _appSettings;
    }
}
