using RESTfulAPIs.Encity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RESTfulAPIs.Service
{
    public class PostService
    {
        private static string ApiBaseUrl = "https://jsonplaceholder.typicode.com";
        private static string ApiPostPath = "/posts";
        private static string ApiDataType = "application/json";

        public async Task Save(Post post)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiBaseUrl);
                var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(post);
                var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ApiDataType);
                var result = await client.PostAsync(ApiPostPath, contentToSend);
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            }
        }

        public async Task<List<Post>> FindAll()
        {
            List<Post> list = new List<Post>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(ApiBaseUrl);
                    var result = await httpClient.GetAsync(ApiPostPath); 
                    var resultContent = await result.Content.ReadAsStringAsync();
                    list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Post>>(resultContent);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }
        public async Task<Post> FindById(string id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ApiBaseUrl);
                    var result = await client.GetAsync($"{ApiPostPath}/{id}");
                    var resultContent = await result.Content.ReadAsStringAsync();
                    var post = Newtonsoft.Json.JsonConvert.DeserializeObject<Post>(resultContent);
                    return post;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> Update (int id, Post updatePost)
        {
            try
            {
                using ( var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ApiBaseUrl);
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(updatePost);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ApiDataType);
                    var result = await client.PutAsync($"{ApiPostPath}/{id}", contentToSend);
                    var resultContent = await result.Content.ReadAsStringAsync();
                    return true;
                }
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
            return false;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ApiBaseUrl);
                    var result = await client.DeleteAsync($"{ApiPostPath}/{id}");
                    return true;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }


    }
}
