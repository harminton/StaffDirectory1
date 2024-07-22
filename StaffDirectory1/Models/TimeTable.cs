using System.ComponentModel.DataAnnotations;

namespace StaffDirectory.Models
{
    public class TimeTable
    {
        //The key validation tells the sql server that the field below it is going to be the primary key of this Class.
        //The (Range) annotation sets a range between to numbers that cant be exceeded by the lowest choosen number or the highes choosen number. in the first period field being a range from (1,5).
        //The (Display Name) data annotation will changes the display name in the model metadata.In the first period field case being "Period 1".

        [Key]
        public int TimeTableID { get; set; }
        public int Staffid { get; set; }
        public int Studentid { get; set; }

        [Range(1,5)]
        [Display(Name = "Period 1")]
        public string FirstPeriod { get; set; }

        [Range(1, 5)]
        [Display(Name = "Period 2")]
        public string SecondPeriod { get; set; }

        [Range(1, 5)]
        [Display(Name = "Period 3")]
        public string ThirdPeriod { get; set; }

        [Range(1, 5)]
        [Display(Name = "Period 4")]
        public string FourthPeriod { get; set; }

        [Range(1, 5)]
        [Display(Name = "Period 5")]
        public string FifthPeriod { get; set; }

        public Staff Staff { get; set; }
        public Students Student { get; set; }

    }
}