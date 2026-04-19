namespace Pure.Dal.Coders.Toolbox;

public class SystemNames
{
    public const string SystemUser = "System";
}

public class CreateTableStatements
{
    private static Dictionary<string, string>? _getCreateStatement;
    public static Dictionary<string, string> GetCreateTableStatement = _getCreateStatement ??= new()
    {
        [nameof(ClassSpecification)] = ClassSpecification,
        [nameof(CodeFlavour)] = CodeFlavour,
        [nameof(CodeObjectMatrix)] = CodeObjectMatrix,
        [nameof(KeyManager)] = KeyManager,
        [nameof(LookUp)] = LookUp
    };

    public const string ClassSpecification = @"CREATE TABLE IF NOT EXISTS ClassSpecification (
            Id INTEGER NOT NULL CONSTRAINT PK_ClassSpecification PRIMARY KEY AUTOINCREMENT,
            Context TEXT NOT NULL,
            LibraryName TEXT NOT NULL,
            ClassName TEXT NOT NULL,
            PropertyName TEXT NULL,
            MethodName TEXT NULL,
            Note TEXT NULL
        )";

    public const string CodeFlavour = @"CREATE TABLE IF NOT EXISTS CodeFlavour (
            Name TEXT NOT NULL CONSTRAINT PK_CodeFlavour PRIMARY KEY,
            Extensions TEXT NOT NULL,
            Description TEXT NOT NULL
        )";

    public const string CodeObjectMatrix = @"CREATE TABLE IF NOT EXISTS CodeObjectMatrix (
            CodeFlavour TEXT NOT NULL,
            InputType TEXT NOT NULL,
            CodeObject TEXT NOT NULL,
            CONSTRAINT PK_CodeObjectMatrix PRIMARY KEY (CodeFlavour, InputType, CodeObject)
        )";

    public const string KeyManager = @"CREATE TABLE IF NOT EXISTS KeyManager (
            GlobalKey TEXT NOT NULL CONSTRAINT PK_KeyManager PRIMARY KEY,
            TableName TEXT NOT NULL,
            KeyInt INTEGER NOT NULL,
            KeyString TEXT NOT NULL,
            KeyComposite TEXT NOT NULL,
            Created TEXT NOT NULL,
            CreatedBy TEXT NOT NULL
        )";

    public const string LookUp = @"CREATE TABLE LookUp (
            Id INTEGER NOT NULL CONSTRAINT PK_LookUp PRIMARY KEY AUTOINCREMENT,
            ParentId INTEGER NOT NULL,
            Name TEXT NOT NULL,
            Value TEXT NULL,
            Text TEXT NOT NULL,
            Note TEXT NULL,
            Archive INTEGER NOT NULL
        )";
}

public class ModifierNames
{
    public const string Public = "public";
    public const string Private = "private";
    public const string Internal = "internal";
    public const string Protected = "protected";
}

