using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using Pure.BO.Coders;
using Pure.Coders.Service;
using Pure.Coders.Service.Mappers;
using Pure.Coders.Toolbox.WPF.Models;
using Pure.Library;
using Pure.Library.CodeGenerator.Extensions;
using Pure.Library.WPF;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows.Controls;

namespace Pure.Coders.Toolbox.WPF.ViewModels;

/// <summary>
/// View model for the CodeGenerator View
/// </summary>
/// <param name="codersService">The <see cref="CodersService"/>.</param>
/// <param name="cachedData">The cached data.</param>
/// <param name="logger">The logger.</param>
public class CodeGeneratorViewModel(
    ICodersService codersService,
    CachedData cachedData,
    ILogger logger) : WorkspaceViewModel
{
    #region Variables
    private readonly ILogger _logger = logger;
    private readonly ICodersService _codersService = codersService;
    private readonly CachedData _cachedData = cachedData;
    #endregion

    #region View Properties
    private ObservableCollection<CodeFlavour> _codeFlavours = [];
    /// <summary>
    /// The "flavour" of code to generate.
    /// </summary>
    public ObservableCollection<CodeFlavour> CodeFlavours { get => _codeFlavours; set => SetProperty(ref _codeFlavours, value); }

    private CodeFlavour? _selectedCodeFlavour;
    public CodeFlavour? SelectedCodeFlavour { get => _selectedCodeFlavour; set => SetProperty(ref _selectedCodeFlavour, value); }

    private ObservableCollection<FileInfo> _files = [];
    /// <summary>
    /// The code files
    /// </summary>
    public ObservableCollection<FileInfo> Files { get => _files; set => SetProperty(ref _files, value); }

    private FileInfo? _selectedFile;
    /// <summary>
    /// The code file selected.
    /// </summary>
    public FileInfo? SelectedFile { get => _selectedFile; set => SetProperty(ref _selectedFile, value); }

    private ObservableCollection<Type> _classes = [];
    /// <summary>
    /// The <see cref="Type"/> (classes) of the <see cref="FileInfo"/> selected.
    /// </summary>
    public ObservableCollection<Type> Classes { get => _classes; set => SetProperty(ref _classes, value); }

    private Type? _selectedClass;
    /// <summary>
    /// The <see cref="Type"/> selected.
    /// </summary>
    public Type? SelectedClass { get => _selectedClass; set => SetProperty(ref _selectedClass, value); }

    private ObservableCollection<PropertyInfo> _properties = [];
    /// <summary>
    /// The <see cref="PropertyInfo"/> objects in the <see cref="Type"/> selected.
    /// </summary>
    public ObservableCollection<PropertyInfo> Properties { get => _properties; set => SetProperty(ref _properties, value); }

    private PropertyInfo? _selectedProperty;
    /// <summary>
    /// The <see cref="PropertyInfo"/> selected.
    /// </summary>
    public PropertyInfo? SelectedProperty { get => _selectedProperty; set => SetProperty(ref _selectedProperty, value); }

    private ObservableCollection<CodeObjectMatrix> _codeObjectMappings = [];
    public ObservableCollection<CodeObjectMatrix> CodeObjectMappings
    {
        get => _codeObjectMappings;
        set => SetProperty(ref _codeObjectMappings, value);
    }

    private CodeObjectMatrix? _selectedCodeObjectMapping;
    public CodeObjectMatrix? SelectedCodeObjectMapping
    {
        get => _selectedCodeObjectMapping;
        set => SetProperty(ref _selectedCodeObjectMapping, value);
    }

    private string? _useNamespace;
    public string? UseNamespace
    {
        get => _useNamespace;
        set => SetProperty(ref _useNamespace, value);
    }

    private string? _generatedCode;
    public string? GeneratedCode { get => _generatedCode; set => SetProperty(ref _generatedCode, value); }
    #endregion

    #region Visibility Properties

    private bool _isFileBrowserVisible = true;
    /// <summary>
    /// Switch specifying the visibility of the File Browser functionality.
    /// </summary>
    public bool IsFileBrowserVisible
    {
        get => _isFileBrowserVisible;
        set => SetProperty(ref _isFileBrowserVisible, value);
    }

    #endregion

    #region Event Handlers
    protected override void OnButtonClick(Button sender) => ButtonClickInvocations[sender.Name].Invoke();

    private Dictionary<string, Action>? _buttonClickInvocations;
    /// <summary>
    /// Dictionary routes the click of a button to its appropriate invocation.
    /// </summary>
    private Dictionary<string, Action> ButtonClickInvocations => _buttonClickInvocations ??= new()
    {
        ["FileBrowserButton"] = () => OnFileBrowserButtonClick()
    };

    private void OnFileBrowserButtonClick()
    {
        OpenFolderDialog dialog = new();
        dialog.ShowDialog();

        DirectoryInfo directory = new(dialog.FolderName);

        Files.Clear();

        foreach (FileInfo file in directory.EnumerateFiles().Where(f => f.Extension == ".dll"))
        {
            Files.Add(file);
        }
        if (Files.Count > 0)
        {

        }
    }

    protected override void OnPropertyChanged(string propertyName)
    {
        try
        {
            PropertyChangeInvocations[propertyName].Invoke();
        }
        catch (Exception) { }
        base.OnPropertyChanged(propertyName);
        SwitchVisibility();
    }

    private Dictionary<string, Action>? _propertyChangeInvocations;
    /// <summary>
    /// Invocations for Property change events.
    /// </summary>
    public Dictionary<string, Action> PropertyChangeInvocations => _propertyChangeInvocations ??= new()
    {
        [nameof(SelectedFile)] = () => OnSelectedFile(),
        [nameof(SelectedClass)] = () => OnClassSelected(),
        [nameof(SelectedCodeObjectMapping)] = () => OnCodeObjectSelected()
    };

    private void OnClassSelected()
    {
        _codersService.InsertClassSpecificationAsync(SelectedClass!);

        PropertyInfo[] properties = [.. SelectedClass!.GetType().GetProperties().Where(f => f.CanWrite)];

        PropertySpecification[] propertySpecifications = PropertySpecificationMapper.Map(properties);

        foreach (PropertyInfo item in SelectedClass!.GetType().GetProperties())
        {
            Properties.Add(item);
        }

        foreach (CodeObjectMatrix item in _cachedData.CodeObjectMappings.Where(f => f.InputType == nameof(Type) && f.CodeFlavour == "C#"))
        {
            CodeObjectMappings.Add(item);
        }
        UseNamespace = Classes.ToArray().DeriveRootNamespace();
    }

    private void OnSelectedFile()
    {
        try
        {
            Assembly assembly = Assembly.LoadFrom(SelectedFile!.FullName);
            Type[] library = [.. assembly.GetTypes().Where(f => !f.Name.StartsWith("<") && !f.Name.StartsWith("_")).OrderBy(o => o.Name)];

            int i = 0;
            while (i < library.Length)
            {
                Type classInstance = library[i++];

                ClassSpecification classSpecification = ClassSpecificationMapper.Map(classInstance);

                Result<ClassSpecification, Exception> result = _codersService.InsertClassSpecificationAsync(classInstance).Result;

                if (!Classes.Any(f => f.Name == classInstance.Name))
                {
                    Classes.Add(classInstance);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
    }

    private void OnCodeObjectSelected()
    {
        if (SelectedClass != null && SelectedProperty == null)
        {
            GeneratedCode = SelectedClass.GenerateCode(SelectedCodeFlavour!.Name, SelectedCodeObjectMapping!.CodeObject);
        }
    }

    protected override void OnItemSelected(object sender)
    {
        if (sender.GetType().BaseType == typeof(ListBox)) { OnListBoxItemSelected((ListBox)sender); }

        if (sender.GetType() == typeof(ComboBox)) { }
    }
    #endregion

    #region Helpers
    public void InitialiseDataSources()
    {
        CodeFlavours = [.. _cachedData.CodeFlavours!];
    }
    private void SwitchVisibility()
    {
        IsFileBrowserVisible = SelectedCodeFlavour != null;
    }
    #endregion
}
