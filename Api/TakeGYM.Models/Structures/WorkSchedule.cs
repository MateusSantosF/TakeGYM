using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TakeGYM.Models.Structures
{
    [Table("Schedule")]
    public class WorkSchedule
    {
        [Key]
        public long WorkScheduleID { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

    }
}
