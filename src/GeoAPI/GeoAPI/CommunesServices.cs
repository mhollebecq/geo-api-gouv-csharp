using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoAPI
{
    public class CommunesServices : GeoServicesBase<Commune>
    {
        public Task<IEnumerable<Commune>> Search(string codePostal = null, string lon = null, string lat = null, string nom = null, string boost = null, string code = null, string codeDepartement = null, string codeRegion = null, string[] fields = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(codePostal))
                parameters.Add("codePostal", codePostal);
            if (!string.IsNullOrEmpty(lon))
                parameters.Add("lon", lon);
            if (!string.IsNullOrEmpty(lat))
                parameters.Add("lat", lat);
            if (!string.IsNullOrEmpty(nom))
                parameters.Add("nom", nom);
            if (!string.IsNullOrEmpty(boost))
                parameters.Add("boost", boost);
            if (!string.IsNullOrEmpty(code))
                parameters.Add("code", code);
            if (!string.IsNullOrEmpty(codeDepartement))
                parameters.Add("codeDepartement", codeDepartement);
            if (!string.IsNullOrEmpty(codeRegion))
                parameters.Add("codeRegion", codeRegion);
            if (fields != null)
                parameters.Add("fields", string.Join(',', fields));


            string uri = "https://geo.api.gouv.fr/communes?" + string.Join('&', parameters.Select(p => $"{p.Key}={p.Value}"));

            return RequestGeos(uri);
        }

        public Task<Commune> GetByCode(string code, string[] fields = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("code", "Code argument must be filled");
            if (fields != null)
                parameters.Add("fields", string.Join(',', fields));

            string uri = $"https://geo.api.gouv.fr/communes/{code}?" + string.Join('&', parameters.Select(p => $"{p.Key}={p.Value}"));
            return RequestGeo(uri);
        }

        public Task<IEnumerable<Commune>> GetByDepartement(string code, string[] fields = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("code", "Code argument must be filled");
            if (fields != null)
                parameters.Add("fields", string.Join(',', fields));

            string uri = $"https://geo.api.gouv.fr/departements/{code}/communes?" + string.Join('&', parameters.Select(p => $"{p.Key}={p.Value}"));
            return RequestGeos(uri);
        }

        public Task<IEnumerable<Commune>> GetByRegion(string code, string[] fields = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("code", "Code argument must be filled");
            if (fields != null)
                parameters.Add("fields", string.Join(',', fields));

            string uri = $"https://geo.api.gouv.fr/regions/{code}/communes?" + string.Join('&', parameters.Select(p => $"{p.Key}={p.Value}"));
            return RequestGeos(uri);
        }
    }
}
