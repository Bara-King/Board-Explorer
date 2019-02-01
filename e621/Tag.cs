using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace e621
{
    public class Tag
    {
        public int id { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public int type { get; set; }
        public bool type_locked { get; set; }
    }

    public class Alias
    {
        public int id { get; set; }
        public string name { get; set; }
        public int alias_id { get; set; }
        public bool pending { get; set; }
    }
}
