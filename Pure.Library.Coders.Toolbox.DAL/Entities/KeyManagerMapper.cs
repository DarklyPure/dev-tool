namespace Pure.Library.Coders.Toolbox.DAL.Entities;

public partial class KeyManagerMapper
{
    public static KeyManager Map(CodeFlavour entity)
    {
        return new()
        {
            TableName = nameof(CodeFlavour),
            KeyString = entity.Name,
            GlobalKey = Guid.NewGuid().ToString(),
            Created = DateTime.Now.ToString(),
            CreatedBy = SystemNames.SystemUser
        };
    }

    public static KeyManager Map(CodeObjectMapping entity)
    {
        return new()
        {
            TableName = nameof(CodeFlavour),
            KeyComposite = $"{entity.CodeFlavour}|{entity.InputType}|{entity.CodeObject}",
            GlobalKey = Guid.NewGuid().ToString(),
            Created = DateTime.Now.ToString(),
            CreatedBy = SystemNames.SystemUser
        };
    }

    public static KeyManager Map(CreatedCodeObject entity)
    {
        return new()
        {
            TableName = nameof(CodeFlavour),
            KeyInt = entity.Id,
            GlobalKey = Guid.NewGuid().ToString(),
            Created = DateTime.Now.ToString(),
            CreatedBy = SystemNames.SystemUser
        };
    }

    public static KeyManager Map(FileLocation entity)
    {
        return new()
        {
            TableName = nameof(CodeFlavour),
            KeyInt = entity.Id,
            GlobalKey = Guid.NewGuid().ToString(),
            Created = DateTime.Now.ToString(),
            CreatedBy = SystemNames.SystemUser
        };
    }

    public static KeyManager Map(LookUp entity)
    {
        return new()
        {
            TableName = nameof(CodeFlavour),
            KeyInt = entity.Id,
            GlobalKey = Guid.NewGuid().ToString(),
            Created = DateTime.Now.ToString(),
            CreatedBy = SystemNames.SystemUser
        };
    }
}
