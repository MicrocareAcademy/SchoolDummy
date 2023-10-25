using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var students = dbContext.Students.Include(p=>p.Class).ToList();

            //binding list of students to the view
            return View(students);
        }

        public IActionResult AddStudent()
        {
            var model = new AddStudentModel();

            model.ClassList = GetClasses();

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveStudent(AddStudentModel model)
        {

            var student = new Student();

            student.FullName = model.StudentName;
            student.RollNo = model.RollNo;
            student.MobileNo = model.MobileNo;
            student.ClassId = model.ClassId;

            var dbContext = new SchoolDBContext(); // open connection

            dbContext.Students.Add(student);    // giving student obj to EF, Insert Stmt

            dbContext.SaveChanges();           // stmt gets executed


            return RedirectToAction("StudentsList");
        }


        public IActionResult EditStudent(int studentId)
        {
            var dbContext = new SchoolDBContext();

            //var studentObj = dbContext.Students.Where(p => p.StudentId == studentId).FirstOrDefault();
            var studentObj = dbContext.Students.FirstOrDefault(p => p.StudentId == studentId);

            var model = new AddStudentModel();

            model.ClassList = GetClasses();

            model.StudentId = studentObj.StudentId;
            model.StudentName = studentObj.FullName;
            model.ClassId = studentObj.ClassId;
            model.RollNo = studentObj.RollNo;

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateStudent(AddStudentModel model)
        {
            var dbContext = new SchoolDBContext();

            var studentObj = dbContext.Students.Where(p => p.StudentId == model.StudentId).FirstOrDefault();

            studentObj.FullName = model.StudentName;
            studentObj.ClassId = model.ClassId;
            studentObj.RollNo = model.RollNo;

            dbContext.Students.Update(studentObj);
            dbContext.SaveChanges();

            return RedirectToAction("StudentsList");
        }

        [HttpPost]
        public IActionResult DeleteStudent(int studentId)
        {
            var dbContext = new SchoolDBContext();

            var studentObj = dbContext.Students.Where(p => p.StudentId == studentId).FirstOrDefault();


            dbContext.Students.Remove(studentObj);
            dbContext.SaveChanges();

            return Json(true);
        }

        private IList<SelectListItem> GetClasses()
        {
            var classesListItems = new List<SelectListItem>();

            var dbContext = new SchoolDBContext();
            var classes = dbContext.Classes.ToList();

            classesListItems.Add(new SelectListItem("-- Select --", null));

            foreach (var classObj in classes)
            {
                var listOption = new SelectListItem(classObj.Title, classObj.ClassId.ToString());

                classesListItems.Add(listOption);
            }

            return classesListItems;
        }
    }
}
