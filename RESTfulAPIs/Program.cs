using RESTfulAPIs.Encity;
using RESTfulAPIs.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTfulAPIs
{
    class Program
    {
        static async Task Main(string[] args)
        {
/*            PostService postService = new PostService();
*/            MyAPIService myApi = new MyAPIService();
/*            List<Post> posts = await postService.FindAll();
*/            List<MyPost> myPosts = await myApi.GetAll();
            /*foreach(var post in posts)
            {
                Console.WriteLine(post.ToString());
            }*/
            await myApi.GetAll();
            foreach (var MyPost in myPosts)
            {
                Console.WriteLine(MyPost.ToString());
            }



        }
    }
}
