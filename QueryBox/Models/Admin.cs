using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace QueryBox.Models
{
    public class Admin
    {
        //Admin Model
        public int admin_id { get; set; }
        public string admin_name { get; set; }
        public string admin_pass { get; set; }

        public Admin() { }

        public Admin(string uname, string pass) {
             admin_name = uname;
             admin_pass = pass;
        }
        public Boolean Admin_validate()
        {
            
            if(admin_name=="Admin" && admin_pass=="Admin")
            { 
            return true;
            }
            return false;
        }
        
        
        
        //student Model
        public int student_id { get; set; }
        [Required]
        public string student_name { get; set; }
        [Required]
        public string student_password { get; set; }
        [Required]
        public string student_lab { get; set; }
        [Required]
        public string student_pcno { get; set; }

        
    }
}