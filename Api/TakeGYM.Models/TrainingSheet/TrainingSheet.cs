using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using TakeGYM.Models.ExerciseTrainingSheet;
using TakeGYM.Models.Teacher;

namespace TakeGYM.Models.TrainingSheet
{
    [Table("TrainingSheet")]
    public class TrainingSheet
    {
        [Key]
        public long TraningSheetID { get; set; }

        public virtual Teacher.Teacher Personal { get; set; }

        public virtual Student.Student Student { get; set; }

        [ForeignKey("StudentID")]
        public long StudentID { get; set; }

        [ForeignKey("PersonalID")]
        public long PersonalID { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }  
        
        public string TrainingSheetObjective { get; set; }
        public List<ExerciseTraningsheet> Exercises { get; set; }


    }
}
