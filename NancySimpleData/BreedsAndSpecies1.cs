using System.Text;
using Nancy;
using Simple.Data;

namespace NancySimpleData
{
    public class BreedsAndSpecies1 : NancyModule
    {
        public BreedsAndSpecies1() : base("2")
        {
            Get["/"] = p =>
                {
                    var db = Database.OpenFile("DemoData.sdf");
                    
                    var results = db.Breeds.All()
                        .Select(db.Breeds.BreedName, db.Breeds.Species.SpeciesName);
                       
                    
                    var sb = new StringBuilder();
                    foreach (var result in results)
                    {
                        sb.AppendFormat("Species: {0} Breed: {1}", result.BreedName, result.SpeciesName);
                    }
                    return sb.ToString();
                };
        }
    }
}