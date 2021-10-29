using RESTfulAPIs.Encity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RESTfulAPIs.Service
{
    public class MyAPIService
    {
        private static string ApiBaseUrl = "https://apis-7thdec.herokuapp.com/api/dduc7th.dec/";
        private static string MyApiPath = "posts";
        private static string ApiDataType = "application/json";

        public async Task<bool> save(MyAPIService posts)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(ApiBaseUrl);
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(posts);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ApiDataType);
                    var result = await httpClient.PostAsync(MyApiPath, contentToSend);
                    var resultContent = await result.Content.ReadAsStringAsync();
                    return true;
                }

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<List<MyPost>> GetAll()
        {
            List<MyPost> myPosts = new List<MyPost>();
            try
            {
                using ( var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(ApiBaseUrl);
                    var result = await httpClient.GetAsync(MyApiPath);
                    var resultContent = await result.Content.ReadAsStringAsync();
                    myPosts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MyPost>>(resultContent);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return myPosts;
        }
    }
}
