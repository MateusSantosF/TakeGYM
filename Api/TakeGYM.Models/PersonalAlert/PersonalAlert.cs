using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using TakeGYM.Models.Entity;
using TakeGYM.Models.Teacher;

namespace TakeGYM.Models.PersonalAlert
{
    [Table("Alert")]
    public class PersonalAlert: BaseEntity
    {

        public Teacher.Teacher Personal { get; set; }

        [ForeignKey("PersonalID")]
        public string PersonalID { get; set; }

        public Student.Student Student { get; set; }

        [ForeignKey("StudentID")]
        public string StudentID { get; set; }

        public string TrainingSheetObjective { get; set; }
    }
}
