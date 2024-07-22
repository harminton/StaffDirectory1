using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace StaffDirectory.Models
{
    public class Students
    {
        
        //The key validation tells the sql server that the field below it is going to be the primary key of this Class.
        //The (Required) annotation tells the server that a particular property is required
        //it well also show and ErrorMessage saying that "Please Enter Student First Name" if this field is not filled, and another saying in the first field case, that "Name can not be more than 25 characters long" when exceeding the stirng limit which is 25.
        //The (Column) allows the name of the tables on the database to be displayed as I choose which in First field case is “FirstName”.
        //The (Display Name) data annotation will changes the display name in the model metadata.In the first field case being "First Name".


        [Key]
        public int StudentID { get; set; }     

        [Column("FirstName")]
        [Required(ErrorMessage = "Please Enter Student First Name"), MaxLength(25, ErrorMessage = "Name can not be more than 25 characters.")]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Student Last Name"), MaxLength(25, ErrorMessage = "Name can not be more than 25 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        

        [Required(ErrorMessage = "Please Enter Student AC Number"), MaxLength(10, ErrorMessage = "Name can not be more than 10 characters.")]
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