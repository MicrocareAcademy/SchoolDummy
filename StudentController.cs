using Microsoft.AspNetCore.Mvc;
using SchoolDummy.Entities;
using SchoolDummy.Models;

namespace SchoolDummy
{
    public class StudentController : Controller
    {
        public IActionResult StudentsList()
        {
            //it opens the channel towards the database
            var dbContext = new SchoolDBContext();

            //EF generate SQL query
            //select * from Students
            //data from DB will be transformed to List of Objects of Type Student Class
            var students = dbContext.Students.ToList();

            //binding list of students to the view
            return View(students);
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveStudent(AddStudentModel model)
        {

            var student = new Student();

            student.FullName = model.StudentName;
            student.RollNo = model.RollNo;
            student.MobileNo = model.MobileNo;
            student.Class = model.ClassName;

            var dbContext = new SchoolDBContext(); // open connection

            dbContext.Students.Add(student);    // giving student obj to EF, Insert Stmt

            dbContext.SaveChanges();           // stmt gets executed


            return RedirectToAction("StudentsList");
        }
    }
}
