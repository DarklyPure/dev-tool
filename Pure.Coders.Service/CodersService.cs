using Microsoft.Extensions.Logging;
using Pure.BO.Coders;
using Pure.BO.Core;
using Pure.Coders.Service.Mappers;
using Pure.Dal.Coders.Toolbox;
using Pure.Dal.Coders.Toolbox.Repositories;
using Pure.Dal.Coders.Toolbox.Setup;
using Pure.Library;
using System.Reflection;
using Entity = Pure.Dal.Coders.Toolbox.Entities;

namespace Pure.Coders.Service;

public class CodersService(CodeFlavourRepository codeFlavourRepository,
    CodeObjectMatrixRepository codeObjectMatrixRepository,
    LookUpRepository lookUpRepository,
    DeveloperToolboxContext developerToolboxContext,
    ClassSpecificationRepository classSpecificationRepository,
    PropertySpecificationRepository propertySpecificationRepository,
    ParameterSpecificationRepository parameterSpecificationRepository,
    MethodSpecificationRepository methodSpecificationRepository,
    PropertySpecificationCodeImplementationRepository propertySpecificationCodeImplementation,
    ILogger logger) : ICodersService
{
    private readonly CodeFlavourRepository _codeFlavourRepository = codeFlavourRepository;
    private readonly CodeObjectMatrixRepository _codeObjectMatrixRepository = codeObjectMatrixRepository;
    private readonly LookUpRepository _lookUpRepository = lookUpRepository;
    private readonly ClassSpecificationRepository _classSpecificationRepository = classSpecificationRepository;
    private readonly PropertySpecificationRepository _propertySpecificationRepository = propertySpecificationRepository;
    private readonly ParameterSpecificationRepository _parameterSpecificationRepository = parameterSpecificationRepository;
    private readonly MethodSpecificationRepository _methodSpecificationRepository = methodSpecificationRepository;
    private readonly PropertySpecificationCodeImplementationRepository _propertySpecificationCodeImplementationRepository = propertySpecificationCodeImplementation;
    private readonly ILogger _logger = logger;
    private readonly DeveloperToolboxContext _developerToolboxContext = developerToolboxContext;

    public bool Initialise()
    {
        try
        {
            _developerToolboxContext.Database.EnsureCreated();
            // Run init - This creates the table if it doesn't yet exist.
            _lookUpRepository.Init();
            _codeFlavourRepository.Init();
            _codeObjectMatrixRepository.Init();
            _classSpecificationRepository.Init();
            _propertySpecificationRepository.Init();
            _methodSpecificationRepository.Init();
            _parameterSpecificationRepository.Init();

            // Get required seeding
            Entity.CodeFlavour[] codeFlavours = Seeds.CodeFlavourSeeds();
            Entity.CodeObjectMatrix[] codeObjectMatrices = Seeds.CodeMatrixSeeds();
            Entity.LookUp[] lookUps = Seeds.LookUpSeeds();

            // Populate the seeds
            int i = 0;
            while (i < codeFlavours.Length)
            {
                Entity.CodeFlavour codeFlavour = codeFlavours[i++];
                _codeFlavourRepository.Insert(codeFlavour);
            }

            i = 0;
            while (i < codeObjectMatrices.Length)
            {
                Entity.CodeObjectMatrix codeObjectMatrix = codeObjectMatrices[i++];
                _codeObjectMatrixRepository.Insert(codeObjectMatrix);
            }

            i = 0;
            //while(i < lookUps.Count)
            //{
            //    // Get all Parents
            //    List<Entity.LookUp> parents = [.. lookUps.Where(f => f.Name!.EndsWith(" List"))];

            //    // Iterate the parents, getting
            //}
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred on initialisation => {classname} => {methodname}", nameof(CodersService), nameof(Initialise));
        }
        return false;
    }

    public async Task<Result<CodeFlavour[], Exception>> AllCodeFlavoursAsync(CancellationToken cancellationToken)
    {
        try
        {
            Result<Entity.CodeFlavour[], Exception> result = await _codeFlavourRepository.GetAllAsync();

            if (result.IsSuccess)
            {
                return Result<CodeFlavour[], Exception>.GenerateResult(CodeFlavourMapper.Map(result.ResultValue!));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on Service {service} => {method}", nameof(CodersService), nameof(AllCodeFlavoursAsync));
            return Result<CodeFlavour[], Exception>.GenerateResult(ex);
        }

        return Result<CodeFlavour[], Exception>.GenerateResult(new Exception("No items found."));
    }

    public async Task<Result<CodeObjectMatrix[], Exception>> AllCodeObjectMappingsAsync(CancellationToken cancellationToken)
    {
        try
        {
            Result<Entity.CodeObjectMatrix[], Exception> result = await _codeObjectMatrixRepository.GetAllAsync();

            if (result.IsSuccess)
            {
                return Result<CodeObjectMatrix[], Exception>.GenerateResult(CodeObjectMatrixMapper.Map(result.ResultValue!));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on Service {service} => {method}", nameof(CodersService), nameof(AllCodeObjectMappingsAsync));
            return Result<CodeObjectMatrix[], Exception>.GenerateResult(ex);
        }

        return Result<CodeObjectMatrix[], Exception>.GenerateResult(new Exception("No items found."));
    }

    public async Task<Result<CodeObjectMatrix[], Exception>> FindCodeObjectMatrixAsync(CodeObjectMatrix item, CancellationToken cancellationToken)
    {
        try
        {
            Result<Entity.CodeObjectMatrix[]?, Exception> result = await _codeObjectMatrixRepository.SearchAsync(CodeObjectMatrixMapper.Map(item));

            if (result.IsSuccess)
            {
                return Result<CodeObjectMatrix[], Exception>.GenerateResult(CodeObjectMatrixMapper.Map(result.ResultValue!));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on Service {service} => {method}", nameof(CodersService), nameof(FindCodeObjectMatrixAsync));
            return Result<CodeObjectMatrix[], Exception>.GenerateResult(ex);
        }
        return Result<CodeObjectMatrix[], Exception>.GenerateResult(new Exception("No match was found for your Code Object Mapping parameters"));
    }

    public async Task<Result<ClassSpecification, Exception>> InsertClassSpecificationAsync(Type type)
    {
        try
        {
            // Map the type to a class specification
            ClassSpecification classSpecification = ClassSpecificationMapper.Map(type);

            // Get the properties
            PropertyInfo[] properties = [.. type.GetProperties().Where(f => f.CanWrite)];

            // Add to the class specification
            classSpecification.PropertySpecifications = PropertySpecificationMapper.Map(properties);

            // Map to a ClassSpecification entity 
            Entity.ClassSpecification classSpecificationEntity = ClassSpecificationMapper.Map(classSpecification);

            // Write to the database - This gives you the class specification Id
            Result<Entity.ClassSpecification?, Exception> resultClassSpecification = await _classSpecificationRepository.InsertAsync(classSpecificationEntity);

            if (resultClassSpecification.IsSuccess)
            {
                return Result<ClassSpecification, Exception>.GenerateResult(ClassSpecificationMapper.Map(resultClassSpecification.ResultValue!));
            }
            return Result<ClassSpecification, Exception>.GenerateResult(resultClassSpecification.Exception!);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on Service {service} => {method}", nameof(CodersService), nameof(AllCodeFlavoursAsync));
            return Result<ClassSpecification, Exception>.GenerateResult(ex);
        }
    }

    public Task<Result<LookUp, Exception>> InsertLookUpAsync(LookUp lookUp)
    {
        throw new NotImplementedException();
    }

    public Task<Result<LookUp[], Exception>> AllLookUpsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Result<PropertySpecificationCodeImplementation[], Exception>> InsertPropertySpecificationCodeImplementationAsync(PropertySpecificationCodeImplementation[] data)
    {
        try
        {
            Result<Entity.PropertySpecificationCodeImplementation[]?, Exception> result = await _propertySpecificationCodeImplementationRepository.InsertAsync(PropertySpecificationCodeImplementationMapper.Map(data));

            if (result.IsSuccess)
            {
                return Result<PropertySpecificationCodeImplementation[], Exception>.GenerateResult(PropertySpecificationCodeImplementationMapper.Map(result.ResultValue!));
            }
            return Result<PropertySpecificationCodeImplementation[], Exception>.GenerateResult(result.Exception!);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on Service {service} => {method}", nameof(CodersService), nameof(AllCodeFlavoursAsync));
            return Result<PropertySpecificationCodeImplementation[], Exception>.GenerateResult(ex);
        }
    }
}
