namespace Pure.BO.Spaces.Attributes
{
    public sealed class SpaceAttribute(string name)
    {
        #region Constructors
        public SpaceAttribute(string name, string type) : this(name) => Type = type;
        #endregion

        #region Properties
        /// <summary>
        /// The name of the attribute
        /// </summary>
        public string Name { get; set; } = name;
        public string? Description { get; set; }
        /// <summary>
        /// The type of the <see cref="SpaceAttribute"/>
        /// </summary>
        public string? Type { get; private set; }
        #endregion

        #region Helpers
        /// <summary>
        /// Adds the passed <see cref="AttributeTypes"/> translating it to it's readable description field
        /// </summary>
        /// <param name="attributeType">The type of the Attribute</param>
        public void SetType(AttributeTypes attributeType) => Type = Enum.GetName(typeof(AttributeTypes), attributeType)!.Replace("_", "")!;
        #endregion
    }
}
