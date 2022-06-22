using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using TakeGYM.Models.Entity;

namespace TakeGYM.Models.Structures
{
    [Table("Schedule")]
    public class Schedule: BaseEntity
    {

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

    }
}
