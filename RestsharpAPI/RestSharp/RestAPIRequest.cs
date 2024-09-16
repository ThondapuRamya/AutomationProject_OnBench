using RestSharp;

namespace APICore.RestSharp
{
    public class RestAPIRequest
    {
        public static RestRequest CreateRequest(string url)
        {
            RestRequest request = new RestRequest(url);           
            return request;
        }

    }
}
