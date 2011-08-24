using System.Collections.Generic;
using System.Dynamic;
using Nancy;
using Simple.Data;

namespace NancySimpleData
{
    public class BreedsAndSpecies5 : NancyModule
    {
        Model model = new Model();
        dynamic db = Database.OpenFile("DemoData.sdf");

        public BreedsAndSpecies5() : base("6")
        {
            Get["/"] = p =>
            {
                dynamic dynamicModel = new ExpandoObject();
                dynamicModel.Breeds = db.Breeds.All()
                    .Select(db.Breeds.BreedName, db.Breeds.Species.SpeciesName);
                dynamicModel.Species = db.Species.All();
                dynamicModel.Title = string.Format("All breeds");
                
                return View["BreedsAndSpecies5", dynamicModel];
            };

            Get["/{speciesid}"] = p =>
            {
                if (p.speciesid == "null")
                {
                    model.Breeds = db.Breeds.All()
                        .Select(db.Breeds.Id, db.Breeds.BreedName, db.Breeds.Species.SpeciesName).Cast<Breed>();
                    model.Title = "All breeds";
                }
                else
                {
                    model.Breeds = db.Breeds.FindAll(db.Breeds.SpeciesId == p.speciesid)
                        .Select(db.Breeds.Id, db.Breeds.BreedName, db.Breeds.Species.SpeciesName).Cast<Breed>();
                    var species = db.Species.FindById(p.speciesid);
                    model.Title = string.Format("All breeds of the species {0}", species.SpeciesName);
                }
               
                return Response.AsJson(model);
            };
        }
    }

    public class Model
    {
        public string Title { get; set; }
        public IEnumerable<dynamic> Breeds { get; set; }
    }

    public class Breed
    {
        public int Id { get; set; }
        public string BreedName { get; set; }
        public string SpeciesName { get; set; }
    }
}
