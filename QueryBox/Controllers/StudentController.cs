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
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult StudentLogin()
        {
            return View();
        }


        
        [HttpPost]
        public ActionResult StudentHome(object sender, EventArgs e)
        {
            StudentDOA login = new StudentDOA();
            
            Student studentdata = new Student();
             studentdata.student_uname = Request.Form["uname"];
             studentdata.student_password= Request.Form["psw"];
            Session["student_uname"] = studentdata.student_uname;
            Session["student_password"] = studentdata.student_password;
           int result= login.validateStudent(studentdata);

            if (result == 1)
            {
                List<Student> student=login.StudentSelectData(studentdata);
                
                foreach (Student students in student)
                {
                    ViewBag.student_id = students.student_id;
                    ViewBag.student_name = students.student_uname;
                    ViewBag.student_lab = students.student_lab;
                    ViewBag.student_pcno = students.student_pc_no;
                   
                }

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30";
                DataTable dtblFaculty = new DataTable();

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("select * from Faculty",sqlCon);
                    sqlDa.Fill(dtblFaculty);
                    sqlCon.Close();
                }
                return View(dtblFaculty);
            }
            else {
                ViewBag.status = "Invalid credentials Try Again!!!";    
                return View("StudentLogin");
            }
        }


        [HttpPost]
        public ActionResult StudentQueries(object sender, EventArgs e)
        {


            StudentDOA login = new StudentDOA();
            Faculty facultydata = new Faculty();
            Student studentdata = new Student();
            studentdata.student_uname = (string)(Session["student_uname"]) ;
            studentdata.student_password= (string)(Session["student_password"]) ;
            facultydata.faculty_id=Request.Form["faculty_id"];
            ViewBag.faculty_id = facultydata.faculty_id;
            int result = login.validateStudent(studentdata);

            if (result == 1)
            {
                List<Student> student = login.StudentSelectData(studentdata);

                foreach (Student students in student)
                {
                    studentdata.student_id = students.student_id;
                    ViewBag.student_id = students.student_id;
                    ViewBag.student_name = students.student_uname;
                    ViewBag.student_lab = students.student_lab;
                    ViewBag.student_pcno = students.student_pc_no;

                }

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Starkushal\Desktop\QueryBoxdb\QueryBoxdb.mdf;Integrated Security=True;Connect Timeout=30";
                DataTable dtblFaculty = new DataTable();

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("select * from Faculty", sqlCon);
                    sqlDa.Fill(dtblFaculty);
                    sqlCon.Close();
                }


                
               int res= login.StudentQuery(studentdata,facultydata);
                if (res == 0)
                {
                    ViewBag.querystatus = "Request Already send To Faculty ID :"+facultydata.faculty_id.ToUpper()+""+facultydata.faculty_username;
                }
                else
                {
                    ViewBag.querystatus = "Query send To Faculty ID :" + facultydata.faculty_id.ToUpper() + "" + facultydata.faculty_username;

                    ViewBag.cancel = 0;
                }

                return View("StudentHome",dtblFaculty);
            }
            else
            {
               ViewBag.status = "Invalid credentials Try Again!!!";
                return View("StudentLogin");
            }


        
        }
            public ActionResult StudentFeedback(object sender, EventArgs e)
            {

                return View();
             }


    }
}