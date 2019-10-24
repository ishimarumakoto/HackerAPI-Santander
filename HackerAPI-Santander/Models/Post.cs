using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerAPI_Santander.Models
{
    public class Post
    {
        //title
        public string title { get; set; }
        //uri
        public string url { get; set; }
        //postedBy
        public string by { get; set; }
        //time in UNIX TIME - return as normal time
        public string time { get; set; }
        //score
        public int score { get; set; }
        //commentCount
        public int descendants { get; set; }


    }
}
