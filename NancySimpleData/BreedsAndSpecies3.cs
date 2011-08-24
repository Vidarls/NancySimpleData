using Nancy;
using Simple.Data;

namespace NancySimpleData
{
    public class BreedsAndSpecies3 : NancyModule    
    {
        public BreedsAndSpecies3() : base ("4")
        {
            Get["/"] = p =>
            {
                var db = Database.OpenFile("DemoData.sdf");
                var results = db.Breeds.All()
                        .Select(db.Breeds.BreedName, db.Breeds.Species.SpeciesName);
                return View["BreedsAndSpecies3", results];
            };
        }
    }
}
