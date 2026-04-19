using Pure.Library;

namespace Pure.BO.Core.Services;

public interface ICoreService
{
    public Task<Result<FileLocation, Exception>> InsertFileLocationAsync(FileLocation item, CancellationToken cancellationToken);
    public Task<Result<FileLocation, Exception>> DeleteFileLocationAsync(FileLocation item, CancellationToken cancellationToken);

    public Task<Result<bool, Exception>> DeleteFileLocationsAsync(FileLocation[] items, CancellationToken cancellationToken);
}
