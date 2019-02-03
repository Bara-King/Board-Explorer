using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using e621;

namespace Board_Explorer
{
    public class Favorite
    {
        public int id { get; set; }

        public static string Search(String username)
        {
            return Post.Search("fav:" + username);
        }
    }
}
