using QueryBox.DAO;
using QueryBox.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QueryBox.Controllers
{
    public class FacultyController : Controller
    {
        // GET: Faculty
        public ActionResult FacultyLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FacultyHome(Object sender, EventArgs args)
        {
            Faculty facultymodel = new Faculty();
            FacultyDAO facultyDao = new FacultyDAO();
            facultymodel.faculty_username = Request.Form["uname"];
            facultymodel.faculty_userpassword = Request.Form["psw"];
            Session["faculty_uname"] = facultymodel.faculty_username;
            Session["faculty_password"] = facultymodel.faculty_userpassword;

            int result = facultyDao.Facultyvalidate(facultymodel.faculty_username, facultymodel.faculty_userpassword);


            if (result == 1)
            {



                List<Faculty> faculty = facultyDao.FacultySelectData(facultymodel);

                foreach (Faculty faculties in faculty)
                {

                    facultymodel.faculty_id = faculties.faculty_id;

                    ViewBag.faculty_name = faculties.faculty_username;
                    ViewBag.faculty_lab = faculties.faculty_lab;

                }
                Session["faculty_id"] = facultymodel.faculty_id;
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30";
                DataTable dtblStudent = new DataTable();

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string sqlquery= "select * from Student where id_student = any(select Id_student from Query where Id_faculty ="+ facultymodel.faculty_id+" )";

                    SqlDataAdapter sqlDa = new SqlDataAdapter(sqlquery, sqlCon);
                    sqlDa.Fill(dtblStudent);
                    sqlCon.Close();
                }
                return View(dtblStudent);

            }
            else
            {
                ViewBag.status = "Invalid Credentials try Again!!!";
                return View("FacultyLogin");

            }


        }

        public ActionResult FacultyResponse()
        {

            Faculty facultymodel = new Faculty();
            FacultyDAO facultyDao = new FacultyDAO();
            facultymodel.faculty_username = Session["faculty_uname"].ToString();
            facultymodel.faculty_userpassword = Session["faculty_password"].ToString();
            facultymodel.faculty_response = Int32.Parse(Request["approve"].ToString());
             int student_id  = Int32.Parse(Request["student_id"].ToString());
            int result = facultyDao.Facultyvalidate(facultymodel.faculty_username, facultymodel.faculty_userpassword);

            if (result == 1)
            {

                List<Faculty> faculty = facultyDao.FacultySelectData(facultymodel);

                foreach (Faculty faculties in faculty)
                {
                    facultymodel.faculty_id = faculties.faculty_id;
                    ViewBag.faculty_name = faculties.faculty_username;
                    ViewBag.faculty_lab = faculties.faculty_lab;
                }

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30";
                DataTable dtblStudent = new DataTable();

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string sqlquery = "select* from Student where id_student = any(select Id_student from Query where Id_faculty =" + facultymodel.faculty_id + " )";

                    SqlDataAdapter sqlDa = new SqlDataAdapter(sqlquery, sqlCon);
                    sqlDa.Fill(dtblStudent);
                    sqlCon.Close();
                }
                
                //update faculty response
               int responseres= facultyDao.facultyresponse(facultymodel,student_id);
                if (responseres == 0)
                {
                    ViewBag.response = "you have already responded query !!!";
                }
                else
                {
                    ViewBag.response = "responded to student sucessfully ";
                }
                    return View("FacultyHome", dtblStudent);
            }
            else
            {
                ViewBag.status = "Invalid Credentials try Again!!!";
                return View("FacultyLogin");
            }
        }
    }
}
    