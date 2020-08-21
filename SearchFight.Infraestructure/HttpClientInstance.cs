using System.Net.Http;

namespace SearchFight.Infraestructure
{
    public class HttpClientInstance
    {
        public static HttpClient Client { get; } = new HttpClient();
    }
}
