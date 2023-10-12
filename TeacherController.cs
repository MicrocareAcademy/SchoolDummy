using Microsoft.AspNetCore.Mvc;
using SchoolDummy.Entities;
using SchoolDummy.Models;

namespace SchoolDummy
{
    public class TeacherController : Controller
    {
        public IActionResult Dashboard()
        {
            var dbContext = new SchoolDBContext();
            var teachers = dbContext.Teachers.ToList();

            // creating an object of TeachersListModel class
            var teachersListModel = new TeachersListModel();

            teachersListModel.Teachers = teachers;
            teachersListModel.NoOfTeachers = teachers.Count;

            return View(teachersListModel);

        }
    }
}
