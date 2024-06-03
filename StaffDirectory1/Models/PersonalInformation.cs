using System.ComponentModel.DataAnnotations;

namespace StaffDirectory.Models
{
    public class PersonalInformation
    {
        [Key]
        public int InformationID { get; set; }
        public int Staffid { get; set; }
        public int Studentid { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter first name"), MaxLength(25)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter first name"), MaxLength(25)]
        public string Lastname { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "Please enter Phone number")]
        [Display(Name = "Contect Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter email ID")]
        [RegularExpression(@"^\W+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }


        public string HomeAddress { get; set; }

        public Staff Staff { get; set; }
        public Students Student { get; set; }


    }
}