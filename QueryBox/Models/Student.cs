using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections;

namespace QueryBox.Models
{
    public class Student
        
    {
       public string student_id { get; set; }
       public string student_uname { get; set; }
       public string student_password { get; set; }
       public string student_lab { get; set; }
       public string student_pc_no { get; set; }
       public Student() { }

      
          }
}