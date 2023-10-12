using Microsoft.AspNetCore.Mvc;
using SchoolDummy.Entities;
using SchoolDummy.Models;
using System.Runtime.InteropServices;

namespace SchoolDummy
{
    public class HomeController : Controller
    {
        public IActionResult Dashboard()
        {
            var dashboardModel = new DashboardModel();

            var dbContext = new SchoolDBContext();

            var teachers = dbContext.Teachers.ToList();
            dashboardModel.Teachers = teachers;
            dashboardModel.TotalTeachers = teachers.Count;

            //dashboardModel.Teachers = dbContext.Teachers.ToList();
            //dashboardModel.TotalTeachers = dashboardModel.Teachers.Count;

            var classes = dbContext.Classes.ToList();
            dashboardModel.Classes = classes;
            dashboardModel.TotalClasses = classes.Count;


            dashboardModel.TotalStudents = dbContext.Students.Count();


            return View(dashboardModel);

        }
    }
}
