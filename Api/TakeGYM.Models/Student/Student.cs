using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;

using TakeGYM.Models.Entity;
using TakeGYM.Models.Structures;

namespace TakeGYM.Models.Student
{
    [Table("Student")]
    public class Student: BaseEntity
    {

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
        
        [MaxLength(14, ErrorMessage = "CPF LENGTH OUT OF BOUNDS")]
        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [MaxLength(9, ErrorMessage = "CEP LENGTH OUT OF BOUNDS")]
        [JsonProperty("cep")]
        public string CEP { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [ForeignKey("TeacherID")]
        [JsonProperty("teacherId")]
        public string TeacherId { get; set; }

        public virtual Teacher.Teacher Teacher { get; set; }

        [JsonProperty("hasPersonal")]
        public bool HasPersonal { get; set; }

        [Column("PersonalSchedule")]
        public Schedule PersonalSchedule { get; set; }
    }
}
