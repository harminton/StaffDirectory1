using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace StaffDirectory.Models
{
    public class Students
    {
        [Key]
        public int StudentID { get; set; }


        [Column("FirstName")]
        [Required(ErrorMessage = "Please Enter Student First Name"), MaxLength(25)]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Student Last Name"), MaxLength(25)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please Enter Student AC Number"), MaxLength(10)]
        [Display(Name = "AC Number")]
        public string AcNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Student Home Room Number")]
        [Display(Name = "Hoome Room Number")]
        public string HomeRoom { get; set; }

        [Required(ErrorMessage = "Enter Day Of Enrollment")]
        
        public DateTime Enrollment { get; set; }


        ICollection<Students> Student { get; set; }
        

    }
}