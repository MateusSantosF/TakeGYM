using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using TakeGYM.Models.Teacher;

namespace TakeGYM.Models.PersonalAlert
{
    [Table("Alert")]
    public class PersonalAlert
    {

        [Key]
        public long PersonalAlertID { get; set; }

        public Teacher.Teacher Personal { get; set; }

        [ForeignKey("PersonalID")]
        public long PersonalID { get; set; }

        public Student.Student Student { get; set; }

        [ForeignKey("StudentID")]
        public long StudentID { get; set; }

        public string TrainingSheetObjective { get; set; }
    }
}
