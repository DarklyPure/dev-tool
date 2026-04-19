using Pure.Dal.TheGarden.Entities;

namespace Pure.Dal.TheGarden.Setup;

public class Seeding
{
    #region Seeds
    public static LookUp[] LookUpSeeds()
        => [
                new(){Id = 1, Name = "Class Name List", Text = "Class Name" },
                new(){Id = 1, Name = "Class Name", Text = "Class Name" }
            ];

    public static Plantae[] PlantaeSeeds()
        => [
                new(){ Genus = "Brassica", Species = "Brassica oleracea", CommonName = "Broccoli"},
                new(){ Genus = "Brassica", Species = "Brassica oleracea", CommonName = "Brussels Sprout"},
                new(){ Genus = "Brassica", Species = "Brassica oleracea", CommonName = "Cauliflower"},
                new(){ Genus = "Asparagus", Species = "Asparagus officinalis", CommonName = "Asparagus"},
                new(){ Genus = "Phaseolus", Species = "Phaseolus vulgaris", CommonName = "Bush Bean"},
                new(){ Genus = "Phaseolus", Species = "Phaseolus vulgaris", CommonName = "Pole Bean"},
                new(){ Genus = "Vicia", Species = "Vicia faba", CommonName = "Broad Bean"},
                new(){ Genus = "Allium", Species = "Allium cepa", CommonName = "Onion"},
                new(){ Genus = "Beta", Species = "Beta vulgaris", CommonName = "Beetroot"},
                new(){ Genus = "Chinensis", Species = "Brassica chinensis", CommonName = "Bok Choy"},
                new(){ Genus = "Brassica", Species = "Brassica oleracea", CommonName = "Cabbage"},
                new(){ Genus = "Daucus", Species = "Daucus carota", CommonName = "Carrot"},
                new(){ Genus = "Apium", Species = "Daucus carota", CommonName = "Celery"},
                new(){ Genus = "Cicla", Species = "Beta vulgaris ssp. cicla", CommonName = "Chard"},
                new(){ Genus = "Zea", Species = "Zea mays", CommonName = "Corn"},
            ];
    #endregion
}
