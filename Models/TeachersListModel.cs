using SchoolDummy.Entities;

namespace SchoolDummy.Models
{
    public class TeachersListModel
    {
        public IList<Teacher> Teachers { get; set; }

        public int NoOfTeachers { get; set; }
    }
}
