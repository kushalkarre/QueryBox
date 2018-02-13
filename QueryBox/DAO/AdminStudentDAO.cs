using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using QueryBox.Models;

namespace QueryBox.DAO
{
    public class AdminStudentDAO
    {


        public int AddStudent(Student student)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string query = "insert into Student (name_student,password_student,lab_student,pc_no_student) values('" + student.student_uname + "','" +student.student_password + "','" + student.student_lab + "','" + student.student_pc_no + "')";

            SqlCommand cmd = new SqlCommand(query, con);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }



        public int DeleteStudent(Student student)
        {
           
           
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string query = "delete from Student where id_student=" + student.student_id;

            SqlCommand cmd = new SqlCommand(query, con);
            int res = cmd.ExecuteNonQuery();
            con.Close();

            return res;
        }

    }
}