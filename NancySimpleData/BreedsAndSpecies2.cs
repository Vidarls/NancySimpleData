using Nancy;
using Simple.Data;

namespace NancySimpleData
{
    public class BreedsAndSpecies2 : NancyModule 
    {
        public BreedsAndSpecies2() : base("3")
        {
            Get["/"] = p =>
            {
                var db = Database.OpenFile("DemoData.sdf");
                var results = db.Breeds.All()
                        .Select(db.Breeds.BreedName, db.Breeds.Species.SpeciesName);
                return View["BreedsAndSpecies2TableView", results];
            };
        }
    }
}