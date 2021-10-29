using System;
using System.Collections.Generic;
using System.Text;

namespace RESTfulAPIs.Encity
{
    public class MyPost
    {
        public int id { get; set; }
        public string image { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int user_id { get; set; }



        public override string ToString()
        {
            return $"ID: {id} \r\n ImageURL: {image}  \r\n Title: {title} \r\n Desc: {description} \r\n UserID: {user_id} ";
        }
    }
}
