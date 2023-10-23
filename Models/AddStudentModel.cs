using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolDummy.Models
{
    public class AddStudentModel
    {
        public string StudentName { get; set; }

        public string RollNo { get; set; }

        public string MobileNo { get; set; }

        public string ClassName { get; set; }

        public int StudentId { get; set; }

        public int? ClassId { get; set; }

        public IList<SelectListItem> ClassList { get; set; }
    }
}
