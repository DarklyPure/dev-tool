using Microsoft.UI.Xaml.Controls;
using System;
using System.Reflection;
using System.Windows.Input;

namespace Pure.Library.WinUI;

/// <summary>
/// Abstract class for a ViewModel
/// </summary>
public abstract class WorkspaceViewModel : ViewModelBase
{
    #region Event Handlers
    private RelayCommand _closeCommand;
    /// <summary>
    /// Returns the command that, when invoked, attempts
    /// to remove this workspace from the user interface.
    /// </summary>
    public ICommand CloseCommand => _closeCommand ??= new RelayCommand(param => OnRequestClose());
    /// <summary>
    /// Raised when this workspace should be removed from the UI.
    /// </summary>
    public event EventHandler RequestClose;
    private void OnRequestClose() => RequestClose?.Invoke(this, EventArgs.Empty);

    private RelayCommand<Button> _buttonClick;
    public ICommand ButtonClick => _buttonClick ??= new RelayCommand<Button>(OnButtonClick);

    private RelayCommand<object> _itemSelected;
    public ICommand ItemSelected => _itemSelected ??= new RelayCommand<object>(OnItemSelected);

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
