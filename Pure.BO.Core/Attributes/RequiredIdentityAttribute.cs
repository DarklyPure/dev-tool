using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pure.BO.Core.Attributes
{
    /// <summary>
    /// <see cref="ValidationAttribute"/> implementation.
    /// </summary>
    /// <remarks>
    /// Validates if 
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class RequiredIdentityAttribute : ValidationAttribute
    {
        #region Constants
        private readonly string[] _propertyNames = ["Id", "PartitionKey", "RowKey"];
        #endregion

        #region Helpers
        /// <summary>
        /// Specifies if 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            StringBuilder stringBuilder = new();

            if (validationContext == null)
            {
                return new(ValidationMessages.CONTEXT_NOT_SUPPLIED);
            }

            Core core = (Core)validationContext.ObjectInstance;

            if (core.Id != null)
            {
                return ValidationResult.Success;
            }
            else
            {
                if (!string.IsNullOrEmpty(core.PartitionKey) && !string.IsNullOrEmpty(core.RowKey))
                {
                    return ValidationResult.Success;
                }
            }

            int size = _propertyNames.Length;
            int i = 0;

            while (i < size)
            {
                string item = _propertyNames[i];
                stringBuilder.Append(FormatErrorMessage(item));
                stringBuilder.Append(ValidationMessages.PRIMARY_KEY_NOT_SET);
                i++;
            }

            return new(stringBuilder.ToString(), ["Id", "PartitionKey", "RowKey"]);
        }
        #endregion
    }
}
