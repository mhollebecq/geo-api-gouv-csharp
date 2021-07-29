using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoAPI
{
    public class RegionsServices : GeoServicesBase<Region>
    {
        public Task<IEnumerable<Region>> Search(string code = null, string codeRegion = null, string nom = null, string[] fields = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(nom))
                parameters.Add("nom", nom);
            if (!string.IsNullOrEmpty(code))
                parameters.Add("code", code);
            if (!string.IsNullOrEmpty(codeRegion))
                parameters.Add("codeRegion", codeRegion);
            if (fields != null)
                parameters.Add("fields", string.Join(',', fields));


            string uri = "https://geo.api.gouv.fr/regions?" + string.Join('&', parameters.Select(p => $"{p.Key}={p.Value}"));

            return RequestGeos(uri);
        }
        public Task<Region> GetByCode(string code, string[] fields = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("code", "Code argument must be filled");
            if (fields != null)
                parameters.Add("fields", string.Join(',', fields));

            string uri = $"https://geo.api.gouv.fr/regions/{code}?" + string.Join('&', parameters.Select(p => $"{p.Key}={p.Value}"));
            return RequestGeo(uri);
        }
    }
}
