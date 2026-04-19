using System.Diagnostics;
using System.Windows.Input;

namespace Pure.Library.WPF;

public class RelayCommand : ICommand
{
    #region Variables

    #endregion

    #region Constructors
    public RelayCommand(Action<object> execute) : this(execute, null) { }
    public RelayCommand(Action<object> execute, Predicate<object>? canExecute)
    {
        ArgumentNullException.ThrowIfNull(execute);
        _execute = execute;
        _canExecute = canExecute;
    }
    #endregion

    #region ICommand Members

    private readonly Predicate<object>? _canExecute;
    [DebuggerStepThrough]
    public bool CanExecute(object? parameter) => _canExecute == null || _canExecute(parameter!);

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    private readonly Action<object> _execute;
    public void Execute(object? parameter)
    {
        if (parameter != null)
        {
            _execute(parameter);
        }
    }
    #endregion
}

public class RelayCommand<T> : ICommand
{
    #region Constructors
    public RelayCommand(Action<T> execute) : this(execute, null) { }
    /// <summary>
    /// Creates a new command.
    /// </summary>
    /// <param name="execute">The execution logic.</param>
    /// <param name="canExecute">The execution status logic.</param>
    public RelayCommand(Action<T> execute, Predicate<T>? canExecute)
    {
        ArgumentNullException.ThrowIfNull(execute);
        _execute = execute;
        _canExecute = canExecute;
    }
    #endregion

    #region ICommand Members

    private readonly Predicate<T>? _canExecute = null;
    [DebuggerStepThrough]
    public bool CanExecute(object? parameter) => _canExecute == null || _canExecute((T)parameter!);

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    private readonly Action<T>? _execute = null;
    public void Execute(object? parameter)
    {
        if (parameter != null && _execute != null)
        {
            _execute((T)parameter);
        }
    }
    #endregion
}
