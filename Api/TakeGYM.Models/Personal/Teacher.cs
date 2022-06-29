using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using TakeGYM.Models.Entity;
using TakeGYM.Models.Structures;

namespace TakeGYM.Models.Teacher
{

    [Table("Teacher")]
    public class Teacher : BaseEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public bool IsPersonal { get; set; }

        [MaxLength(14, ErrorMessage = "CPF LENGTH OUT OF BOUNDS")]
        public string CPF { get; set; }

        [InverseProperty("Teacher")]
        public virtual  List<Student.Student> Students { get; set; }
      
        public List<Schedule> WorkSchedules { get; set; }

        public virtual List<PersonalAlert.PersonalAlert> Alerts { get; set; }
    }
}
