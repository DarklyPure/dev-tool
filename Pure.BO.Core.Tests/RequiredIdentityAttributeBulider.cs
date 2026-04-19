namespace Pure.BO.Core.Attributes.Tests;

public class RequiredIdentityAttributeBuilder
{
	private string _errorMessage = Guid.NewGuid().ToString();
	private string _errorMessageResourceName = Guid.NewGuid().ToString();
	private Type _errorMessageResourceType;

	private RequiredIdentityAttribute? _object;

	public RequiredIdentityAttribute Build()
	{
		return _object ??= new()
		{
			ErrorMessage = _errorMessage,
			ErrorMessageResourceName = _errorMessageResourceName,
			ErrorMessageResourceType = _errorMessageResourceType
		};
	}

	public  RequiredIdentityAttributeBuilder WithErrorMessage(string value)
	{
		_errorMessage = value;
		return this;
	}

	public  RequiredIdentityAttributeBuilder WithErrorMessageResourceName(string value)
	{
		_errorMessageResourceName = value;
		return this;
	}

	public  RequiredIdentityAttributeBuilder WithErrorMessageResourceType(Type value)
	{
		_errorMessageResourceType = value;
		return this;
	}

}
