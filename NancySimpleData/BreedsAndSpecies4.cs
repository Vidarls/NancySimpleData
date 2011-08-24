using System.Dynamic;
using Nancy;
using Simple.Data;

namespace NancySimpleData
{
    public class BreedsAndSpecies4 : NancyModule 
    {
        public BreedsAndSpecies4() : base("5")
        {
            dynamic model = new ExpandoObject();

            Get["/"] = p =>
            {
                var db = Database.OpenFile("DemoData.sdf");
                var results = db.Breeds.All()
                    .Select(db.Breeds.BreedName, db.Breeds.Species.SpeciesName);
                                
                model.Title = string.Format("All breeds", p.speciesname);
                model.Breeds = results;
                return View["BreedsAndSpecies4", model];
            };

            Get["/{speciesname}"] = p =>
            {
                var db = Database.OpenFile("DemoData.sdf");
                var results = db.Breeds.Query()
                    .Where(db.Breeds.Species.SpeciesName == p.speciesname)
                    .Select(db.Breeds.BreedName, db.Breeds.Species.SpeciesName);
                model.Title = string.Format("All breeds of the species {0}", p.speciesname);
                model.Breeds = results;
                return View["BreedsAndSpecies4", model];
            };
        }
    }
}