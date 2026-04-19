using Pure.Library.Coders.Toolbox.DAL.Entities;
using Pure.Library.SQLite.Entities;

namespace Pure.Library.Coders.Toolbox.DAL.Extensions;

/// <summary>
/// Extensions for Entities.
/// </summary>
/// <remarks>
/// This is in place to produce a Table creation string for any database changes.
/// These are in place of migrations and generally only get used the once.
/// They are preserved here to keep the entities clear.
/// </remarks>
public static class EntityExtensions
{
    public static string CreateTableSql(this CodeFlavour _) =>
        @"CREATE TABLE IF NOT EXISTS CodeFlavour (
                        Name TEXT NOT NULL CONSTRAINT PK_CodeFlavours PRIMARY KEY,
                        Extensions TEXT NOT NULL,
                        Description TEXT NOT NULL)";

    public static string CreateTableSql(this CodeObjectMapping _) =>
        @"CREATE TABLE IF NOT EXISTS CodeObjectMapping (
                        CodeFlavour TEXT NOT NULL,
                        InputType TEXT NOT NULL,
                        CodeObject TEXT NOT NULL,
                        CONSTRAINT PK_CodeObjectMappings PRIMARY KEY (CodeFlavour, InputType, CodeObject))";

    public static string CreateTableSql(this CreatedCodeObject _) =>
        @"CREATE TABLE IF NOT EXISTS CreatedCodeObject (
                        Id INTEGER NOT NULL CONSTRAINT PK_CreatedCodeObjects PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Code BLOB NULL,
                        DoNotFluash INTEGER NOT NULL)";

    public static string CreateTableSql(this KeyManager _) =>
        @"CREATE TABLE IF NOT EXISTS KeyManager (
                        GlobalKey TEXT NOT NULL CONSTRAINT PK_KeyManager PRIMARY KEY,
                        TableName TEXT NOT NULL,
                        KeyInt INTEGER NOT NULL,
                        KeyString TEXT NOT NULL,
                        KeyComposite TEXT NOT NULL,
                        Created TEXT NOT NULL,
                        CreatedBy TEXT NOT NULL)";

    public static string CreateTableSql(this FileLocation _) =>
        @"CREATE TABLE IF NOT EXISTS FileLocation (
                        Id INTEGER NOT NULL CONSTRAINT PK_Locations PRIMARY KEY AUTOINCREMENT,
                        LocationType TEXT NULL,
                        Path TEXT NULL,
                        Description TEXT NULL)";

    public static string CreateTableSql(this LookUp _) =>
        @"CREATE TABLE IF NOT EXISTS LookUp (
                        Id INTEGER NOT NULL CONSTRAINT PK_LookUps PRIMARY KEY,
                        ParentId INTEGER NOT NULL,
                        Name TEXT NOT NULL,
                        Value TEXT NULL,
                        Text TEXT NOT NULL,
                        Note TEXT NULL,
                        Archive INTEGER NOT NULL)";

    public static string CreateTableSql(this SystemDetail _) =>
        @"CREATE TABLE IF NOT EXISTS SystemDetail (
                        Application TEXT NOT NULL,
                        Name TEXT NOT NULL,
                        Value TEXT NULL,
                        Created TEXT NOT NULL,
                        Updated TEXT NOT NULL,
                        CONSTRAINT PK_SystemDetails PRIMARY KEY (Application, Name)";

}
