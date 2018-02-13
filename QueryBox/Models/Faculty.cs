using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;

namespace QueryBox.Models
{
    public class Faculty
    {
        public string faculty_id { get; set; }
        public string faculty_username { get; set; }
        public string faculty_userpassword { get; set; }
        public string faculty_lab { get; set; }
        public string faculty_status { get; set; }
        public int faculty_response { get; set; }
    //  public DbSet<Faculty> faculty { get; set; }
        public Faculty() { }
   }
}