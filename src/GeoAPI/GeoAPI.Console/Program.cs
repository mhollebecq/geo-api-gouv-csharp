using System;
using System.Threading.Tasks;

namespace GeoAPI.Console
{
    class Program
    {
        async static Task Main(string[] args)
        {
            CommunesServices communesServices = new CommunesServices();
            DepartementsServices departementsServices = new DepartementsServices();
            RegionsServices regionsServices = new RegionsServices();

            var communeSearch = await communesServices.Search(nom: "Poil", fields: new string[] { "name", "region", "departement", "contour", "centre" });
            var communeByCode = await communesServices.GetByCode("58211", fields: new string[] { "name", "region", "departement" });
            var communeByDpt = await communesServices.GetByDepartement("23");
            //var communeByRegion = await communesServices.GetByRegion("27");

            var departementSearch = await departementsServices.Search(nom: "var");
            var departementByCode = await departementsServices.GetByCode("23");
            var departementsByRegion = await departementsServices.GetByRegion("27");

            var regionsSearch = await regionsServices.Search(nom: "Occitanie");
            var regionsByCode = await regionsServices.GetByCode("01");
            System.Console.WriteLine("Hello World!");
        }
    }
}
