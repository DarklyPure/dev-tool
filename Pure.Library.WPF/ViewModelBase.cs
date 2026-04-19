using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pure.Library.WPF;

public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
{
    private bool disposed = false;

    #region Property Change Handlers

    /// <summary>
    /// Raised when a property on this object has a new value.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Raises this object's PropertyChanged event.
    /// </summary>
    /// <param name="propertyName">The property that has a new value.</param>
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler? handler = PropertyChanged;

        if (handler != null)
        {
            PropertyChangedEventArgs e = new(propertyName);
            handler(this, e);
        }
    }

    #endregion

    #region DisplayName
    /// <summary>
    /// Returns the user-friendly name of this object.
    /// Child classes can set this property to a new value,
    /// or override it to determine the value on-demand.
    /// </summary>
    public virtual string DisplayName { get; protected set; } = string.Empty;
    #endregion

    #region Helpers
    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(field, value)) { return false; }

        field = value;

        if (propertyName != null) { OnPropertyChanged(propertyName); }

        return true;
    }
    #endregion

    #region IDisposable Members
    // Finalizer
    ~ViewModelBase()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        // Prevent finalizer from running since cleanup is done
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Release managed resources here
                Console.WriteLine("Managed resources released.");
            }
            // Release unmanaged resources here
            Console.WriteLine("Unmanaged resources released.");

            disposed = true;
        }
    }
    #endregion
}
