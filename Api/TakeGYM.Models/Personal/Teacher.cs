using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using TakeGYM.Models.Structures;

namespace TakeGYM.Models.Teacher
{

    [Table("Teacher")]
    public class Teacher
    {

        [Key]
        public long TeacherID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public bool IsPersonal { get; set; }

        [MinLength(14, ErrorMessage = "CPF LENGTH OUT OF BOUNDS")]
        [MaxLength(14, ErrorMessage = "CPF LENGTH OUT OF BOUNDS")]
        public string CPF { get; set; }

        public virtual  List<Student.Student> Students { get; set; }
      
        public List<WorkSchedule> WorkSchedules { get; set; }

        public virtual List<PersonalAlert.PersonalAlert> Alerts { get; set; }
    }
}
