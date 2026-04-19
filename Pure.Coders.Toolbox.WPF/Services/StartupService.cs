using Pure.Library;
using Pure.Library.CodeGenerator.Services;
using Pure.Library.Coders.Toolbox;
using Pure.Library.Interfaces;
using Pure.Library.Services;
using System.IO;

namespace Pure.Coders.Toolbox.WPF.Services;

public sealed class StartupService : StartUpServiceBase
{
    public StartupService(AppSettings appSettings, DirectoryManagementService directoryManagementService) : base(appSettings, directoryManagementService) { }

    public override IAppSettings RefreshEnvironment()
    {
        base.RefreshEnvironment();

        AppSettings appSettings = (AppSettings)_appSettings;

        Result<DirectoryInfo, Exception> result = _directoryManagementService.GetOrCreateDirectory(Path.Combine(appSettings.ApplicationRootDirectory, appSettings.ImportsDirectory));

        if (result.IsSuccess) { appSettings.ImportsDirectory = result.ResultValue!.FullName; }

        result = _directoryManagementService.GetOrCreateDirectory(Path.Combine(appSettings.ApplicationRootDirectory, appSettings.ExportsDirectory));
        if (result.IsSuccess) { appSettings.ExportsDirectory = result.ResultValue!.FullName; }

        result = _directoryManagementService.GetOrCreateDirectory(Path.Combine(appSettings.ApplicationRootDirectory, appSettings.LogsDirectory));
        if (result.IsSuccess) { appSettings.LogsDirectory = result.ResultValue!.FullName; }

        result = _directoryManagementService.GetOrCreateDirectory(Path.Combine(appSettings.ApplicationRootDirectory, appSettings.DatabaseDirectory));
        if (result.IsSuccess) { appSettings.DatabaseDirectory = result.ResultValue!.FullName; }
        return _appSettings;
    }
}
