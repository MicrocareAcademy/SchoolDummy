using Microsoft.AspNetCore.Mvc;
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
    }
}
