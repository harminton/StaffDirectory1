using StaffDirectory1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffDirectory.Models

{
    public class Staff
    {
        public int StaffID { get; set; }

        //The (MaxLegth) is an annotation that allows to specify additional property validations.
        //(25, ErrorMessage = "Name can not be more than 25 characters) validation is  allowing a max property of 25 string characrters,meaning that no more than 25 characters can be added in this field.
        // it well also show and ErrorMessage saying that "Name can not be more than 25 characters long" when exceeding the stirng limit which is 25.
        //The (Column) allows the name of the tables on the database to be displayed as I choose which in First field case is “FirstName”.
        //The (Display Name) data annotation will changes the display name in the model metadata.In the first field case being "First Name".

        [MaxLength(25, ErrorMessage = "Name can not be more than 25 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(25, ErrorMessage = "Name can not be more than 25 characters.")]
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