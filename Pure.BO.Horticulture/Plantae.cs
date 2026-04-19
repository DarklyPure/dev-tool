using Pure.Library.Extensions;

namespace Pure.BO.Horticulture
{
    public sealed class Plantae : Core.Core
    {
        #region Constructors
        public Plantae()
        {
            // Load up the default Classification details
            Classification.Add(ClassificationName.Kingdom.GetNameValue(), string.Empty);
            Classification.Add(ClassificationName.Phylum.GetNameValue(), string.Empty);
            Classification.Add(ClassificationName.Class.GetNameValue(), string.Empty);
            Classification.Add(ClassificationName.Subclass.GetNameValue(), string.Empty);
            Classification.Add(ClassificationName.Order.GetNameValue(), string.Empty);
            Classification.Add(ClassificationName.Family.GetNameValue(), string.Empty);
            Classification.Add(ClassificationName.Genus.GetNameValue(), string.Empty);
            Classification.Add(ClassificationName.Species.GetNameValue(), string.Empty);
        }
        #endregion

        #region Properties
        public Dictionary<string, string> Classification { get; private set; } = [];
        public string? CommonName { get; set; }
        public string? Description { get; set; }
        #endregion
    }
}
