using System.ComponentModel.DataAnnotations;

namespace Pure.BO.Core
{
    public sealed class Person : Core
    {
        #region Properties
        /// <summary>
        /// The title
        /// </summary>
        /// <example>
        /// Miss, Mrs, Mr etc.
        /// </example>
        public string? Title { get; set; }
        /// <summary>
        /// The Gender
        /// </summary>
        /// <example>
        /// F,M,N etc.
        /// </example>
        public string? Gender { get; set; }
        /// <summary>
        /// The first name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The FirstName is required")]
        public string? FirstName { get; set; }
        /// <summary>
        /// The last name
        /// </summary>
        [Required(AllowEmptyStrings = true, ErrorMessage = "The LastName is required")]
        public string? LastName { get; set; }
        /// <summary>
        /// The date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        #endregion
    }
}
