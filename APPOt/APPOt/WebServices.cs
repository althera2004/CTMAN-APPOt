using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace APPOt
{
    public class WebServices
    {
        public HttpResponse Get(string Url)
        {
            var request = WebRequest.Create(Url);
            request.ContentType = "application/json";
            request.Method = "GET";
            using (HttpWebResponse httpResponse = request.GetResponse() as HttpWebResponse)
            {
                return BuildResponse(httpResponse);
            }
        }

        private static HttpResponse BuildResponse(HttpWebResponse httpResponse)
        {
            using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var content = reader.ReadToEnd();
                var response = new HttpResponse
                {
                    Content = content,
                    HttpStatusCode = httpResponse.StatusCode
                };
                return response;
            }
        }

        public async Task<HttpResponse> GetAsync(string Url)
        {
            var request = WebRequest.Create(Url);
            request.ContentType = "application/json";
            request.Method = "GET";
            using (HttpWebResponse httpResponse = await request.GetResponseAsync() as HttpWebResponse)
            {
                return BuildResponse(httpResponse);
            }
        }
    }
}
