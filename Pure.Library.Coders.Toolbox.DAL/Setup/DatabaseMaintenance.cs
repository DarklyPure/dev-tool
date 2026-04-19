using Microsoft.Extensions.Logging;
using Pure.Library.Coders.Toolbox.DAL.Entities;
using Pure.Library.Coders.Toolbox.DAL.Extensions;
using Pure.Library.SQLite.Extensions.Utilities;
using Pure.Library.SQLite.Entities;

namespace Pure.Library.Coders.Toolbox.DAL.Setup;

public class DatabaseMaintenance :  Maintenance<DeveloperToolboxContext>
{
    private Dictionary<string, Func<string>> _tableCreateCommands = new()
    {
        [nameof(LookUp)] = () => new LookUp().CreateTableSql(),
        [nameof(CodeFlavour)] = () => new CodeFlavour().CreateTableSql(),
        [nameof(CodeObjectMapping)] = () => new CodeObjectMapping().CreateTableSql(),
        [nameof(KeyManager)] = () => new KeyManager().CreateTableSql(),
        [nameof(FileLocation)] = () => new FileLocation().CreateTableSql(),
        [nameof(LookUp)] = () => new LookUp().CreateTableSql(),
        [nameof(CreatedCodeObject)] = () => new CreatedCodeObject().CreateTableSql(),
        [nameof(SystemDetail)] = () => new SystemDetail().CreateTableSql()
    };

    public DatabaseMaintenance(DeveloperToolboxContext context, ILogger logger) : base(context, logger)
    {
        _logger = logger;
    }

    private readonly ILogger _logger;

    public void RefreshDatabase() => RefreshDatabase(_tableCreateCommands);
    public void SeedDatabase() => new Seeding(_context, _logger).SeedDatabase();
}
