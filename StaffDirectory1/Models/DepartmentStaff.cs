namespace StaffDirectory.Models
{
    public class DepartmentStaff
    {
        public int DepartmentStaffID { get; set; }
        public int Departmentid { get; set; }
        public int Staffid { get; set; }


        public Departments Departments { get; set; }
        public Staff Staff { get; set; }

    }
}