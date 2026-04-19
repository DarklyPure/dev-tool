using Microsoft.Extensions.Logging;
using Pure.Library.Coders.Toolbox.DAL.Entities;

namespace Pure.Library.Coders.Toolbox.DAL.Setup;

public class Seeding(DeveloperToolboxContext context, ILogger logger)
{

    private readonly ILogger _logger = logger;
    private readonly DeveloperToolboxContext _context = context;

    public void SeedDatabase()
    {
        InsertCodeFlavour();
        InsertCodeObjectMapping(); 
    }

    #region Inserts
    private void InsertCodeObjectMapping()
    {
        CodeObjectMapping[] entities = CodeObjectMappingSeeds();

        int i = 0;
        while (i < entities.Length)
        {
            CodeObjectMapping entity = entities[i++];

            if( !_context.CodeObjectMappings.Any(x=> x.CodeFlavour ==  entity.CodeFlavour && x.InputType == entity.InputType && x.CodeObject == entity.CodeObject))
            {
                try
                {
                    _context.CodeObjectMappings.Add(entity);
                    int result = _context.SaveChanges();

                    if (result > 0)
                    {
                        InsertKeyManager(entity);
                    }
                }
                catch (Exception ex) 
                {
                    _logger.LogError(ex, "Error inserting entity {entity} into table {table}", nameof(CodeObjectMapping), nameof(CodeObjectMapping));
                }
            }
        }
    }
    private void InsertCodeFlavour()
    {
        CodeFlavour[] entities = CodeFlavourSeeds();

        int i = 0;
        while (i < entities.Length)
        {
            CodeFlavour entity = entities[i++];

            if (!_context.CodeFlavours.Any(x => x.Name == entity.Name))
            {
                try
                {
                    _context.CodeFlavours.Add(entity);
                    int result = _context.SaveChanges();

                    if (result > 0)
                    {
                        InsertKeyManager(entity);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error inserting entity {entity} into table {table}", nameof(CodeFlavour), nameof(CodeFlavour));
                }
            }
        }
    }
    private void InsertKeyManager(CodeFlavour e)
    {
        try
        {
            KeyManager entity = new()
            {
                TableName = nameof(CodeFlavour),
                KeyString = e.Name,
                GlobalKey = Guid.NewGuid().ToString(),
                Created = DateTime.UtcNow.ToString(),
                CreatedBy = SystemNames.SystemUser
            };
            bool exists = _context.Identities.Any(a => a.TableName == entity.TableName && a.KeyString == entity.KeyString);

            if (!exists)
            {
                _context.Identities.Add(entity);
                _context.SaveChanges();
            }   
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on {name} of entity {entity}", nameof(KeyManager), nameof(CodeFlavour));
        }
    }
    private void InsertKeyManager(CodeObjectMapping e)
    {
        try
        {
            KeyManager entity = new()
            {
                TableName = nameof(CodeObjectMapping),
                KeyComposite = $"{e.CodeFlavour}|{e.InputType}|{e.CodeObject}",
                GlobalKey = Guid.NewGuid().ToString(),
                Created = DateTime.UtcNow.ToString(),
                CreatedBy = SystemNames.SystemUser
            };

            bool exists = _context.Identities.Any(a => a.TableName == entity.TableName && a.KeyComposite == entity.KeyComposite);

            if (!exists)
            {
                _context.Identities.Add(entity);
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on {name} of entity {entity}", nameof(KeyManager), nameof(CodeObjectMapping));
        }
    }
    private void InsertKeyManager(LookUp e)
    {
        try
        {
            KeyManager entity = new()
            {
                TableName = nameof(CodeFlavour),
                KeyInt = e.Id,
                GlobalKey = Guid.NewGuid().ToString(),
                Created = DateTime.UtcNow.ToString(),
                CreatedBy = SystemNames.SystemUser
            };

            bool exists = _context.Identities.Any(a => a.TableName == entity.TableName && a.KeyInt == entity.KeyInt);

            if (!exists)
            {
                _context.Identities.Add(entity);
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on {name} of entity {entity}", nameof(KeyManager), nameof(LookUp));
        }
    }
    #endregion

    private LookUp[] LookUpSeeds()
    {
        return
            [
                new LookUp(){Id = 1, ParentId = 0, Name = ""}
            ];
    }
    private CodeObjectMapping[] CodeObjectMappingSeeds()
    {
        return
            [
                new CodeObjectMapping(){ CodeFlavour = "C#", InputType = "Type",CodeObject = "Builder"},
                new CodeObjectMapping(){ CodeFlavour = "Typescript", InputType = "Type", CodeObject = "Builder"},
                new CodeObjectMapping(){ CodeFlavour = "Typescript", InputType = "Type", CodeObject = "Interface"},
                new CodeObjectMapping(){ CodeFlavour = "Typescript", InputType = "Type", CodeObject = "Class"},
                new CodeObjectMapping(){ CodeFlavour = "Typescript", InputType = "PropertyInfo", CodeObject = "Property"},
                new CodeObjectMapping(){ CodeFlavour = "C#", InputType = "Type", CodeObject = "Commented Properties"},
            ];
    }
    private CodeFlavour[] CodeFlavourSeeds()
    {
        return
            [
                new CodeFlavour(){ Name = "C#", Extensions = ".cs", Description = "C Sharp."},
                new CodeFlavour(){ Name = "Typescript", Extensions = ".ts", Description = "Typescript."}
            ];
    }
}
