using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDummy.Entities;

namespace SchoolDummy
{
    public class ClassRoomController : Controller
    {
        public IActionResult ClassRoomsList()
        {
            var dbContext = new SchoolDBContext();

            var classes = dbContext.Classes.ToList();

            return View(classes);
        }
        public IActionResult ClassDetails(int classId)
        {
            var dbContext = new SchoolDBContext();

            var classObj = dbContext.Classes.Include(p=>p.Students).FirstOrDefault(p=>p.ClassId == classId);

            return View(classObj);
        }
    }
}
