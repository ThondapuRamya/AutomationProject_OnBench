using RestSharp;

namespace APICore.RestSharp
{
    public class RestAPIResponse
    {
        public static RestResponse response { get; set; }
        public static RestResponse SendRequest(HTTPMethod requestType, RestRequest restRequest)
        {
            RestClient client = new RestClient();
            

            switch (requestType)
            {
                case HTTPMethod.GET:
                    response = client.Get(restRequest);
                    break;
                case HTTPMethod.POST:
                    response = client.Post(restRequest);
                    break;
                case HTTPMethod.PUT:
                    response = client.Put(restRequest);
                    break;
                case HTTPMethod.DELETE:
                    response = client.Delete(restRequest);
                    break;
                case HTTPMethod.PATCH:
                    response = client.Patch(restRequest);
                    break;

            }
            return response;
        }

    }
}
