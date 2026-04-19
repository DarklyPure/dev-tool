namespace Pure.Library;

public readonly struct ResultBinary<TValue>
{

    #region Variables
    private readonly TValue? _result;
    private readonly bool _success;
    #endregion

    #region Constructors
    private ResultBinary(TValue result)
    {
        _result = result;
        _success = true;
    }
    public ResultBinary() => _success = false;
    #endregion

    #region Properties
    public bool IsSuccess => _success;

    public TValue? ResultValue => _result;
    #endregion

    #region Implicit Operators
    public static implicit operator ResultBinary<TValue>(TValue value) => new ResultBinary<TValue>(value);
    #endregion
}
