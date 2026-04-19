using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pure.Library.WinUI;

/// <summary>
/// A simple implementation of ICommand for MVVM command binding.
/// </summary>
/// <remarks>
/// Creates a new command with a can-execute predicate.
/// </remarks>
public partial class RelayCommand(Action<object> execute, Predicate<object> canExecute) : ICommand
{
    private readonly Action<object> _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    private readonly Predicate<object> _canExecute = canExecute;

    public event EventHandler CanExecuteChanged;

    /// <summary>
    /// Creates a new command that can always execute.
    /// </summary>
    public RelayCommand(Action<object> execute) : this(execute, null) { }

    public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

    public void Execute(object parameter) => _execute(parameter);

    /// <summary>
    /// Raises the CanExecuteChanged event to refresh UI bindings.
    /// </summary>
    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}

/// <summary>
/// Creates a new command with a can-execute predicate.
/// </summary>
public partial class RelayCommand<T>(Action<T> execute, Predicate<T> canExecute) : ICommand
{
    private readonly Action<T> _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    private readonly Predicate<T> _canExecute = canExecute;

    public event EventHandler CanExecuteChanged;

    /// <summary>
    /// Creates a new command that can always execute.
    /// </summary>
    public RelayCommand(Action<T> execute) : this(execute, null) { }

    public bool CanExecute(object parameter) => _canExecute?.Invoke((T)parameter) ?? true;

    public void Execute(Object parameter) => _execute((T)parameter);

    /// <summary>
    /// Raises the CanExecuteChanged event to refresh UI bindings.
    /// </summary>
    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}

public partial class RelayCommandAsync(Func<object, Task> executeAsync, Predicate<object> canExecute = null) : ICommand
{
    private readonly Func<object, Task> _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
    private readonly Predicate<object> _canExecute = canExecute;
    private bool _isExecuting;

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter) => !_isExecuting && (_canExecute?.Invoke(parameter) ?? true);

    public async void Execute(object parameter)
    {
        if (!CanExecute(parameter)) { return; }

        try
        {
            _isExecuting = true;
            RaiseCanExecuteChanged();
            await _executeAsync(parameter);
        }
        finally
        {
            _isExecuting = false;
            RaiseCanExecuteChanged();
        }
    }

    public void RaiseCanExecuteChanged() =>
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}

public partial class RelayCommandAsync<T>(Func<T, Task> executeAsync, Predicate<T> canExecute = null) : ICommand
{
    private readonly Func<T, Task> _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
    private readonly Predicate<T> _canExecute = canExecute;
    private bool _isExecuting;

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter) => !_isExecuting && (_canExecute?.Invoke((T)parameter) ?? true);

    public async void Execute(object parameter)
    {
        if (!CanExecute(parameter)) { return; }

        try
        {
            _isExecuting = true;
            RaiseCanExecuteChanged();
            await _executeAsync((T)parameter);
        }
        finally
        {
            _isExecuting = false;
            RaiseCanExecuteChanged();
        }
    }

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
