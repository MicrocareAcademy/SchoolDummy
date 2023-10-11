using Microsoft.AspNetCore.Mvc;
using SchoolDummy.Entities;

namespace SchoolDummy
{
    public class HomeController : Controller
    {
        public IActionResult Dashboard()
        {
            //it opens the channel towards the database
            var dbContext = new SchoolDBContext();

            //EF generate SQL query
            //select * from Students
            //data from DB will be transformed to List of Objects of Type Student Class
            IList<Student> students = dbContext.Students.ToList();

            //return View("Dashboard",students);
            return View(students);

        }
    }
}
