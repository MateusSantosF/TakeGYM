using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using TakeGYM.Models.ExerciseTrainingSheet;

namespace TakeGYM.Models.Exercise
{
    [Table("Exercise")]
    public class Exercise
    {
        [Key]
        public long ExerciseID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string BodyRegion {get;set;}

        public virtual List<ExerciseTraningsheet> TrainingSheets { get; set; }
    }
}
