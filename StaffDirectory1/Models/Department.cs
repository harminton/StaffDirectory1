using System.ComponentModel.DataAnnotations;

namespace StaffDirectory.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentID { get; set; }
        public String? DepartmentName { get; set; }

    }
}