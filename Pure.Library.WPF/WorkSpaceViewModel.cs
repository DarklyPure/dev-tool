using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pure.Library.WPF;

/// <summary>
/// Abstract class for a ViewModel
/// </summary>
public abstract class WorkspaceViewModel : ViewModelBase
{
    #region Event Handlers
    private RelayCommand? _closeCommand;
    /// <summary>
    /// Returns the command that, when invoked, attempts
    /// to remove this workspace from the user interface.
    /// </summary>
    public ICommand CloseCommand => _closeCommand ??= new RelayCommand(param => OnRequestClose());
    /// <summary>
    /// Raised when this workspace should be removed from the UI.
    /// </summary>
    public event EventHandler? RequestClose;
    private void OnRequestClose() => RequestClose?.Invoke(this, EventArgs.Empty);

    private RelayCommand<Button>? _buttonClick;
    public ICommand ButtonClick => _buttonClick ??= new RelayCommand<Button>(OnButtonClick);

    private RelayCommand<object>? _itemSelected;
    public ICommand ItemSelected => _itemSelected ??= new RelayCommand<object>(OnItemSelected);

    private RelayCommand<ListBox>? _listBoxItemSelected;
    public ICommand ListBoxItemSelected => _listBoxItemSelected ??= new RelayCommand<ListBox>(OnListBoxItemSelected);

    protected virtual void OnListBoxItemSelected(ListBox box) { }

    private RelayCommand<ComboBox>? _comboBoxItemSelected;
    public ICommand ComboBoxItemSelected => _comboBoxItemSelected ??= new RelayCommand<ComboBox>(OnComboBoxItemSelected);

    protected virtual void OnComboBoxItemSelected(ComboBox box) { }
    #endregion

    #region Helpers
    public virtual void InvokePropertyChange()
    {
        try
        {
            PropertyInfo[] properties = GetType().GetProperties();
            int i = 0;
            while (i < properties.Length)
            {
                PropertyInfo property = properties[i++];

                if (!string.IsNullOrEmpty(property.Name))
                {
                    OnPropertyChanged(property.Name);
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected virtual void OnButtonClick(Button sender) { }
    protected virtual void OnItemSelected(object sender) { }
    #endregion
}
