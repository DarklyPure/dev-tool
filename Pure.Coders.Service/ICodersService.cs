using Pure.BO.Coders;
using Pure.BO.Core;
using Pure.Library;

namespace Pure.Coders.Service;

public interface ICodersService
{
    public bool Initialise();
    public Task<Result<CodeFlavour[], Exception>> AllCodeFlavoursAsync(CancellationToken cancellationToken);
    public Task<Result<CodeObjectMatrix[], Exception>> AllCodeObjectMappingsAsync(CancellationToken cancellationToken);
    public Task<Result<CodeObjectMatrix[], Exception>> FindCodeObjectMatrixAsync(CodeObjectMatrix item, CancellationToken cancellationToken);
    public Task<Result<ClassSpecification, Exception>> InsertClassSpecificationAsync(Type type);
    public Task<Result<LookUp, Exception>> InsertLookUpAsync(LookUp lookUp);
    public Task<Result<LookUp[], Exception>> AllLookUpsAsync();
    public Task<Result<PropertySpecificationCodeImplementation[], Exception>> InsertPropertySpecificationCodeImplementationAsync(PropertySpecificationCodeImplementation[] data);
}
