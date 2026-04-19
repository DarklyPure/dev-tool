namespace Pure.Library;

/// <summary>
/// A Result instance containing the details of the actions result
/// </summary>
/// <typeparam name="TResult"></typeparam>
/// <typeparam name="TException"></typeparam>
/// <remarks>
/// One thing to note here is that TResult and TException must 
/// differ. You can't, for instance decide you're actual required result
/// is an exception.
/// Doing so confuses the Implied operator section.
/// </remarks>
public readonly struct Result<TResult, TException>
{
    #region Factory
    public static Result<TResult, Exception> GenerateResult(TResult r)
    {
        Result<TResult, Exception> result = r;
        return result;
    }
    public static Result<TResult, TException> GenerateResult(TException e)
    {
        Result<TResult, TException> result = e;
        return result;
    }
    #endregion

    #region Variables
    private readonly TResult? _result;
    private readonly TException? _exception;
    private readonly bool _success;
    #endregion

    #region Constructors
    private Result(TResult? result, TException? exception, bool success)
    {
        _result = result;
        _exception = exception;
        _success = success;
    }
    #endregion

    #region Helpers
    public bool IsSuccess => _success;

    public TResult? ResultValue => _result;

    public TException? Exception => _exception;
    #endregion

    #region Implicit Operators
    public static implicit operator Result<TResult, TException>(TResult result) => new(result, default, true);

    public static implicit operator Result<TResult, TException>(TException exception) => new(default, exception, false);
    #endregion
}
