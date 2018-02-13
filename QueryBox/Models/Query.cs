using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueryBox.Models
{
    public class Query
    {
        public string id_query { get; set; }
        public string status_query { get; set; }
        public string id_student { get; set; }
        public string id_faculty { get; set; }

        public Query()
        {
        }
    }
}