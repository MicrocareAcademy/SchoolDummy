using Microsoft.AspNetCore.Mvc;
using SchoolDummy.Entities;

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
    }
}
