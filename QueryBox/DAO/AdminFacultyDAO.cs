using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using QueryBox.Models;

namespace QueryBox.DAO
{
    public class AdminFacultyDAO
    {
        public int AddFaculty(Faculty faculty)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string query = "insert into Faculty (name_faculty,password_faculty,lab_faculty,stutus_faculty) values('" + faculty.faculty_username + "','" + faculty.faculty_userpassword + "','" +faculty.faculty_lab   + "'," +faculty.faculty_status + ")";

            SqlCommand cmd = new SqlCommand(query, con);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int DeleteFaculty(string id)
        {
            string  Faculty_id = id;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string query = "delete from Faculty where Id_faculty=" + Faculty_id;

            SqlCommand cmd = new SqlCommand(query, con);
            int res = cmd.ExecuteNonQuery();
            con.Close();

            return res;
        }

    }
}