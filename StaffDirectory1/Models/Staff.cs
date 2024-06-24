using StaffDirectory1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffDirectory.Models

{
    public class Staff
    {
        public int StaffID { get; set; }



        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Column("LastName")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display (Name ="Status")]
        public string StaffStatus { get; set; }
        [Display (Name ="Home Room Teacher Code")]
        public string TeacherCode { get; set; }
        [Display(Name = "Home Room Number")]
        public string HomeRoom { get; set; }


        ICollection<PersonalInformation> Information { get; set; }
    }
}