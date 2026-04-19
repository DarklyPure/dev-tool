namespace Pure.Library;

public enum TimeInterval
{
    Daily,
    Monthly,
    Hourly
}
public static class ResourceNameConstants
{
    public const string APPLICATION_NAME = "ApplicationName";
    public const string APPLICATION_DESCRIPTION = "ApplicationDescription";
    public const string FILE_NAME_PREFIX = "File_Name_";
    public const string CONTENT_NAME_PREFIX = "Content_";
    public const string ROOT_DIRECTORY_DESIGNATOR_USER = "[USER]";
    public const string ROOT_DIRECTORY_DESIGNATOR_APPLICATION = "[APPLICATION]";
    public const string PUBLISHED_DATE = "PublishedDate";
    public const string UPDATED_DATE = "UpdatedDate";
    public const string VERSION = "Version";
    public const string DIRECTORY_ROOT_APPLICATION_PREFIX = "DirectoryRootApplication_";
    public const string DIRECTORY_PREFIX = "Directory_";
    public const string SPECIAL_FOLDER_WRAPPERS = "[]";
    public const string SPECIAL_FOLDER_PREFIX_WRAPPER = "[";
    public const string SPECIAL_FOLDER_SUFFIX_WRAPPER = "]";
    public const string RESOURCES_DIRECTORY = "Resources";
    public const string INSTALL_DIRECTORY = "InstallationDirectory";
}
public static class DeploymentDictionaryKeyConstants
{
    public const string DIRECTORY_ROOT_USER = "DirectoryRootUser";
    public const string DIRECTORY_ROOT_APPLICATION = "DirectoryRootApplication";
    public const string DIRECTORY_PREFIX = "Directory";
}
public static class CodeModifierNames
{
    public const string PUBLIC = "public";
    public const string PRIVATE = "private";
    public const string PROTECTED = "protected";
    public const string SEALED = "sealed";
}
public static class CodingLanguageNames
{
    public const string CSharp = "C#";
    public const string Javascript = "Javascript";
    public const string Typescript = "Typescript";
}
public static class DynamicTextRepresentationConstants
{
    /// <summary>
    /// Represents a Special folder name
    /// </summary>
    public const string SPECIAL_FOLDER = "SPECIALFOLDER";
    /// <summary>
    /// Represents the Application name
    /// </summary>
    public const string APPLICATION_NAME = "APPLICATIONNAME";
}
public class CodeObjectNames
{
    public const string PropertyInstance = "Property";
    public const string BuilderClass = "Builder Class";
    public const string Variable = "Variable";
    public const string BuilderVariable = "Builder-Variable";
    public const string OneToOnePropertySet = "One to One Property Set";
    public const string BuilderWithMethod = "Builder With Method";
}
public enum MonitoringObjectType
{
    File,
    Directory
}
public enum MonitoringRuleAction
{
    Unset,
    Move,
    Copy,
    Delete,
    Zip
}
