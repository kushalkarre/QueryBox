using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using QueryBox.Models;

namespace QueryBox.DAO
{
    public class FacultyDAO
    {

        public int Facultyvalidate(string uname, string password)
        {
            int count = 0;

            string faculty_uname = uname;
            string faculty_password = password;



            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string query = "select * from Faculty where name_faculty='" + faculty_uname + "' and password_faculty='" + faculty_password + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                count++;
            }
            con.Close();
            return count;
        }


        public List<Faculty>   FacultySelectData(Faculty facultydata)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string query = "select * from Faculty where name_faculty='" + facultydata.faculty_username + "'and password_faculty='" + facultydata.faculty_userpassword + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader datareader = cmd.ExecuteReader();

            List<Faculty> facultyobject = new List<Faculty>();
            while (datareader.Read())
            {
                facultydata.faculty_id = datareader[0].ToString().ToUpper();
                facultydata.faculty_username = datareader[1].ToString().ToUpper();
                facultydata.faculty_lab = datareader[3].ToString().ToUpper();
                facultydata.faculty_status = datareader[4].ToString().ToUpper();

                facultyobject.Add(facultydata);
            }
            con.Close();

            return facultyobject;
        }


        public List<Student> StudentSelectData(Faculty facultydata)
        {
            Student studentdata = new Student();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            
            string query = "select * from Student  where id_student =any (select Id_student from Query where Id_faculty="+facultydata.faculty_id+")";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader datareader = cmd.ExecuteReader();
            List<Student> studentobject = new List<Student>();
            while (datareader.Read())
            {
                studentdata.student_id = datareader[0].ToString().ToUpper();
                studentdata.student_uname = datareader[1].ToString().ToUpper();
                studentdata.student_lab = datareader[3].ToString().ToUpper();
                studentdata.student_pc_no = datareader[4].ToString().ToUpper();
                studentobject.Add(studentdata);

            }
            con.Close();
            return studentobject;
       }


        public int facultyresponse(Faculty facultydata,int student_id)
        {
            
            int res = facultydata.faculty_response;
            int studentid = student_id;
            string facultyname = facultydata.faculty_username;
            Student studentdata = new Student();
            Query querydata = new Query();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            string query = "select * from Query where Id_faculty="+facultydata.faculty_id+"and Id_student="+student_id+"";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader datareader = cmd.ExecuteReader();

            SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30");
            con2.Open();

            while (datareader.Read())
            {
                                  
                querydata.status_query= datareader[1].ToString().ToUpper();

                if (querydata.status_query.Equals("1"))
                {
                    string query2 = "update Query set status_query=" + res + " where id_student=" + student_id + " and id_faculty=" + facultydata.faculty_id + "";
                    SqlCommand cmd2 = new SqlCommand(query2, con2);
                    cmd2.ExecuteNonQuery();
                    con2.Close();
                    con.Close();
                    return 1;

                }
                else
                {
                    con2.Close();
                    con.Close();
                    return 0;
                }
            }
            return 0;
             }
       }
}