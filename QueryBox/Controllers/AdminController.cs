using QueryBox.DAO;
using QueryBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QueryBox.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminHome(object sender, EventArgs e)
        {  
            
            string admin_username = Request.Form["uname"];
            string admin_password = Request.Form["psw"];
            ViewBag.status = "Invalid Creadential try again!!!";
            
            Admin admin = new Admin(admin_username,admin_password);

            bool result = admin.Admin_validate();
            {

            }
            if (result==true)
            {
                return View();

            }
            return View("AdminLogin");
        }

        
        [HttpPost]
        public ActionResult AdminStudentRegistration(object sender, EventArgs e)
        {
            Student student = new Student();
            AdminStudentDAO students = new AdminStudentDAO();
                student.student_uname= Request.Form["username"];
            student.student_password = Request.Form["password"];
            student.student_lab = Request.Form["student_lab"];
            student.student_pc_no = Request.Form["student_pc_no"];
            int result=students.AddStudent(student);
            ViewBag.studreg = "failed to register" +student.student_uname;
            if (result == 1)
            {
                ViewBag.studreg = "sucessfully registered "+student.student_uname;
            }
            
            return View("AdminHome");
        }
        
        [HttpPost]
        public ActionResult AdminStudentDelete(object sender, EventArgs e)
        {
            Student student = new Student();
            AdminStudentDAO students = new AdminStudentDAO();
            student.student_id = Request.Form["Student_Id"];
            Admin removestudent =new Admin();
            int result = students.DeleteStudent(student);
            ViewBag.studdel = "failed to delete student";
            if (result == 1)
            {
                ViewBag.studdel = "sucesfully deleted " +student.student_id;
            }
            
            return View("AdminHome");
        }
        
        //faculty
        [HttpPost]
        public ActionResult AdminFacultyRegistration(object sender, EventArgs e)
        {
            AdminFacultyDAO registration = new AdminFacultyDAO();
            Faculty reg = new Faculty();
            reg.faculty_username = Request.Form["Username"];
            reg.faculty_userpassword= Request.Form["password"];
            reg.faculty_lab = Request.Form["lab_faculty"];
            reg.faculty_status = Request.Form["lab_status"];
            
            int result=registration.AddFaculty(reg);
               ViewBag.facultyreg = "failed to register" + reg.faculty_username;
            if (result == 1)
            {
                 ViewBag.facultyreg = "sucessfully registered " +reg.faculty_username;
            }

          
            return View("AdminHome");
        }

        [HttpPost]
        public ActionResult AdminFacultyDelete(object sender, EventArgs e)
        {
            AdminFacultyDAO delete = new AdminFacultyDAO();
            Faculty faculties = new Faculty();
            faculties.faculty_id  =  Request.Form["Faculty_Id"].ToString();
            int result = delete.DeleteFaculty(faculties.faculty_id);
            ViewBag.regddel = "failed to delete student";
            if (result == 1)
            {
                ViewBag.regddel = "sucesfully deleted " + faculties.faculty_id;
            }

            return View("AdminHome");
        }



    }
}