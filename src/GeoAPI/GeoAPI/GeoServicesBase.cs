using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeoAPI
{
    public abstract class GeoServicesBase<T>
    {
        protected static async Task<T> RequestUrl<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri))
                {
                    using (HttpResponseMessage response = await httpClient.SendAsync(request))
                    {
                        var contentJson = await response.Content.ReadAsStringAsync();
                        var communes = JsonSerializer.Deserialize<T>(contentJson,
                            new JsonSerializerOptions()
                            {
                                PropertyNameCaseInsensitive = true,
                                Converters =
                                {
                                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                                }
                            });

                        return communes;
                    }
                }
            }
        }

        protected static Task<IEnumerable<T>> RequestGeos(string uri)
            => RequestUrl<IEnumerable<T>>(uri);
        protected static Task<T> RequestGeo(string uri)
            => RequestUrl<T>(uri);
    }
}