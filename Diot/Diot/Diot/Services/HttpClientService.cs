using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Diot.Services
{
    public class HttpClientService
    {
        #region  Fields

        private readonly HttpClient client;

        #endregion

        #region Methods

        #region Constructors

        public HttpClientService()
        {
            client = new HttpClient {MaxResponseContentBufferSize = 256000};
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #endregion

        public async Task<JObject> GetJObjectAsync(string url)
        {
            var results = await client.GetStringAsync(url);
            return JObject.Parse(results);
        }

        public async Task<byte[]> GetImageByteArrayAsync(string url)
        {
            return await client.GetByteArrayAsync(url);
        }

        public async Task<string> GetStringAsync(string url)
        {
            return await client.GetStringAsync(url);
        }

        #endregion
    }
}