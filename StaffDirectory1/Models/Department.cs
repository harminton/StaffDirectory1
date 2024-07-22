using System.ComponentModel.DataAnnotations;

namespace StaffDirectory.Models
{
    public class Departments
    {
        //The key validation tells the sql server that the field below it is going to be the primary key of this Class.

        [Key]
        public int DepartmentID { get; set; }
        public String? DepartmentName { get; set; }

    }
}