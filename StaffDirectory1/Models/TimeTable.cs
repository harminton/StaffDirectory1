using System.ComponentModel.DataAnnotations;

namespace StaffDirectory.Models
{
    public class TimeTable
    {
        [Key]
        public int TimeTableID { get; set; }
        public int Staffid { get; set; }
        public int Studentid { get; set; }

        [Display(Name = "Period 1")]
        public string FirstPeriod { get; set; }

        [Display(Name = "Period 2")]
        public string SecondPeriod { get; set; }
        [Display(Name = "Period 3")]
        public string ThirdPeriod { get; set; }

        [Display(Name = "Period 4")]
        public string FourthPeriod { get; set; }
        [Display(Name = "Period 5")]
        public string FifthPeriod { get; set; }

        public Staff Staff { get; set; }
        public Students Student { get; set; }

    }
}