using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffDirectory.Models
{
    public class PersonalInformation
    {

        //The key validation tells the sql server that the field below it is going to be the primary key of this Class.
        //The (Required) annotation tells the server that a particular property is required.
        //It well also show and ErrorMessage saying that "Please Enter First Name" if this field is not filled, and another saying in the FirstName field case, that "Name can not be more than 25 characters long" when exceeding the stirng limit which is 25.
        //The (Column) allows the name of the tables on the database to be displayed as I choose which in First field case is “FirstName”.
        //The (Display Name) data annotation will changes the display name in the model metadata.In the first field case being "First Name".
        //The (DataType(DataType.PhoneNumber)Applies the DataTypeAttribute attribute to the Phone data field by specifying the PhoneNumber enumerated value in the associated metadata class. This indicates to the Text.ascx field template that the email address display is customized
        //The (DataType(DataType.EmailAddress) Applies the DataTypeAttribute attribute to the EmailAddress data field by specifying the EmailAddress enumerated value in the associated metadata class. This indicates to the Text.ascx field template that the email address display is customized.
        //The (RegularExpression) annotation validates wather the value of an associated input control matches that of specifide pattern by a regular expression.
        //This annotation also has a ErrorMesage that says email is not valide in case anything other then these regular expresison are inputed in this field.

        [Key]
        public int InformationID { get; set; }
        public int Staffid { get; set; }
        public int Studentid { get; set; }
        
        
        [Required(ErrorMessage = "Please Enter First Name"), MaxLength(25, ErrorMessage = "Name can not be more than 25 characters.")]
        [Column("FirstName")]
        public string FirstName { get; set; }

        
        [Required(ErrorMessage = "Please Enter First Name"), MaxLength(25, ErrorMessage = "Name can not be more than 25 characters.")]
        [Column("LastName")]
        public string Lastname { get; set; }

        [MaxLength(20, ErrorMessage = "Name can not be more than 20 characters.")]
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