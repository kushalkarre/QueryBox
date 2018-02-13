using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using QueryBox.Models;
using System.Collections;

namespace QueryBox.DAO
{
    public class StudentDOA
    {
       
        public int validateStudent(Student studentdata)
        {
            int count = 0;
           
            string student_uname = studentdata.student_uname;
            string student_password = studentdata.student_password;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string query = "select * from Student where name_student='" + student_uname + "' and password_student='" + student_password + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {

                count++;
            }
            con.Close();
            return count;

        }

        public List<Student> StudentSelectData(Student studentdata)
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string query = "select * from Student where name_student='"+studentdata.student_uname+"'and password_student='"+studentdata.student_password+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader datareader = cmd.ExecuteReader();

             List<Student>  studentobject= new List<Student>();
             while (datareader.Read())
             {
                studentdata.student_id = datareader[0].ToString().ToUpper();
                 studentdata.student_uname= datareader[1].ToString().ToUpper();
                 studentdata.student_lab= datareader[3].ToString().ToUpper();
                 studentdata.student_pc_no = datareader[4].ToString().ToUpper();

                studentobject.Add(studentdata); 
                    }
            con.Close();

            return studentobject;
        }


        public List<Faculty> SelectfacultyData()
        {
            Faculty facultydata=new Faculty();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string query = "select * from Faculty ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader datareader = cmd.ExecuteReader();

            List<Faculty> facultyobject = new List<Faculty>();
            while (datareader.Read())
            {
                facultydata.faculty_id = datareader[0].ToString().ToUpper();
                facultydata.faculty_username= datareader[1].ToString().ToUpper();
                facultydata.faculty_lab = datareader[3].ToString().ToUpper();
                facultydata.faculty_status = datareader[4].ToString().ToUpper();
  //            facultydata.faculty.Add(facultydata);
                facultyobject.Add(facultydata);

            }
            con.Close();

            return facultyobject;

        }


        public int StudentQuery(Student studentdata,Faculty facultydata)
        {
            
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string query = "insert into Query (status_query,Id_student,Id_faculty) values(" +1 + "," + studentdata.student_id + "," + facultydata.faculty_id+")";

            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                int res = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            { 
            

                return 0;
            
            }
            con.Close();
            return 1;
        }



    }
}



