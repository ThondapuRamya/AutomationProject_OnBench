using APICore.RestSharp;
using APITestcases.Models;
using APITestcases.Providers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestcases.Pages
{
    internal class UsersPage
    {
        static RestResponse restResponse { get; set; }
        static string BaseUrl = ConfigurationProvider.apiDetails.APIBaseUrl;
        public static RestResponse GetListOfUsers(string pageValue)
        {
            
            string resourceUrl = "api/users?page="+pageValue;

            string url = BaseUrl+resourceUrl;

           RestRequest request= RestAPIRequest.CreateRequest(url);

             restResponse = RestAPIResponse.SendRequest(HTTPMethod.GET, request);
            return restResponse;

        }

        public static bool ValidateGetListOfUsers(int startingRange, int endingRange)
        {
            GetUsers getUsers= JsonConvert.DeserializeObject<GetUsers>(restResponse.Content);
           var allRecords= getUsers.data.ToList();
            foreach (var record in allRecords)
            {
                if (!(record.id >= startingRange || record.id <= endingRange))
                    return false;
            }           
            return true;
        }


        public static RestResponse CreateResource()
        {

            string resourceUrl = "api/users";
            string url = BaseUrl+resourceUrl;

           RestRequest request= RestAPIRequest.CreateRequest(url);
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../", @"Data", "CreateResourcePayload.json");
           string jsonData= File.ReadAllText(jsonFilePath);
            request.AddParameter("application/json", jsonData, ParameterType.RequestBody);
            restResponse = RestAPIResponse.SendRequest(HTTPMethod.POST, request);
            return restResponse;
        }

        public static bool ValidateCreateRequestResponse()
        {
            CreateUser createUserResponse =  JsonConvert.DeserializeObject<CreateUser>(restResponse.Content);
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../", @"Data", "CreateResourcePayload.json");
            string jsonData = File.ReadAllText(jsonFilePath);
            dynamic data = JObject.Parse(jsonData);
            if (createUserResponse.name ==Convert.ToString( data.name )&& createUserResponse.job == Convert.ToString(data.job))
                return true;

            return false;
        }
    }
}
