using Pure.Dal.Coders.Toolbox.Entities;

namespace Pure.Dal.Coders.Toolbox.Setup;

/// <summary>
/// A collection of "seeds" required on first run.
/// </summary>
public static class Seeds
{
    /// <summary>
    /// All <see cref="CodeFlavour"/> entities required at start-up.
    /// </summary>
    /// <returns>A list of <see cref="CodeFlavour"/> entities.</returns>
    public static CodeFlavour[] CodeFlavourSeeds()
        =>
            [
                new CodeFlavour() { Name = "C#", Extensions = ".cs", Description = "C Sharp."},
                new CodeFlavour() { Name = "Typescript", Extensions = ".ts", Description = "Typescript."}
            ];

    /// <summary>
    /// All <see cref="CodeObjectMatrix"/> entities required at start-up.
    /// </summary>
    /// <returns>A list of <see cref="CodeObjectMatrix"/> entities.</returns>
    public static CodeObjectMatrix[] CodeMatrixSeeds()
        =>
            [
                new CodeObjectMatrix() { CodeFlavour = "C#", InputType = "Type",CodeObject = "Builder"},
                new CodeObjectMatrix() { CodeFlavour = "Typescript", InputType = "Type", CodeObject = "Builder"},
                new CodeObjectMatrix() { CodeFlavour = "Typescript", InputType = "Type", CodeObject = "Interface"},
                new CodeObjectMatrix() { CodeFlavour = "Typescript", InputType = "Type", CodeObject = "Class"},
                new CodeObjectMatrix() { CodeFlavour = "Typescript", InputType = "PropertyInfo", CodeObject = "Property"},
                new CodeObjectMatrix() { CodeFlavour = "C#", InputType = "Type", CodeObject = "Commented Properties"},
            ];

    public static LookUp[] LookUpSeeds()
        =>
            [
                new LookUp(){ Name = "CRUD Operation List", Text = "CRUD Operation"},
                new LookUp(){ Name = "CRUD Operation", Text = "Create" },
                new LookUp(){ Name = "CRUD Operation", Text = "Read" },
                new LookUp(){ Name = "CRUD Operation", Text = "Update" },
                new LookUp(){ Name = "CRUD Operation", Text = "Delete" },
            ];
}
