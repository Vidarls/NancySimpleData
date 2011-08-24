using System.Collections.Generic;
using System.Dynamic;
using Nancy;
using Simple.Data;

namespace NancySimpleData
{
    public class BreedsAndSpecies6 : NancyModule
    {
       dynamic db = Database.OpenFile("DemoData.sdf");

        public BreedsAndSpecies6() : base("7")
        {
            dynamic model = new ExpandoObject();

            Get["/"] = p =>
            {
                model.Breeds = db.Breeds.All()
                    .Select(db.Breeds.Id, db.Breeds.BreedName, db.Breeds.Species.SpeciesName);
                model.Species = db.Species.All();
                model.Title = string.Format("All breeds");

                return View["BreedsAndSpecies6BreedList", model];
            };

            Get["/add"] = p =>
            {
                model.Species = new List<object>();
                foreach (var species in db.Species.All())
                {
                    model.Species.Add(new
                    {
                        species.SpeciesName,
                        species.Id,
                        IsSelected = ""
                    });
                }
                model.Title = "Add new breed";
                model.Action = "/" + ModulePath + "/add";
                model.Breed = new {BreedName = ""};
                return View["BreedsAndSpecies6Form", model];
            };

            Post["/add"] = p =>
            {
                db.Breeds.Insert(BreedName: Request.Form.BreedName,
                                    SpeciesId: Request.Form.SpeciesId);
                
                return Response.AsRedirect("/" + ModulePath);
            };

            Get["/{breedid}"] = p =>
            {
                model.Breed = db.Breeds.FindById(p.breedid);
                model.Species = new List<object>();
                foreach (var species in db.Species.All())
                {
                    model.Species.Add(new
                    {
                        species.SpeciesName,
                        species.Id,
                        IsSelected = species.Id == model.Breed.SpeciesId ? "selected=\"selected\"" : ""
                    });
                }
                model.Title = "Editing " + model.Breed.BreedName;
                model.Action = "/" + ModulePath + "/update/" + p.breedid;
                return View["BreedsAndSpecies6Form", model];
            };

            Post["/update/{breedid}"] = p =>
            {
                db.Breeds.UpdateById(Id: p.breedid,
                                        BreedName: Request.Form.BreedName,
                                        SpeciesId: Request.Form.SpeciesId);
                return Response.AsRedirect("/" + ModulePath);
            };

            Get["/delete/{breedid}"] = p =>
            {
                db.Breeds.DeleteById(p.breedid);
                return Response.AsRedirect("/" + ModulePath);
            };

        }
   }
}
