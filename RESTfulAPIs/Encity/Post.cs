using System;
using System.Collections.Generic;
using System.Text;

namespace RESTfulAPIs.Encity
{
    public class Post
    {
        public string title { get; set; }
        public string body { get; set; }
        public int userId { get; set; }

        public override string ToString()
        {
            return $"Tittle: {title} " + Environment.NewLine + $"Body: {body} " + Environment.NewLine + $" User ID: {userId}";
        }

    }

    
}
