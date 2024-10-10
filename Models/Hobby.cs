using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Me.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        [DataType(DataType.Date)]  //just shows date, w/o => shows time 
        [Display(Name = "Last Worked On")]
        public DateTime LastWorkedOn { get; set; }
        public string? Rating { get; set; }

    }
}
