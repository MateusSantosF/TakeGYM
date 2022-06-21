using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TakeGYM.Models.ExerciseTrainingSheet
{
    [Table("Exercise_Trainingsheet")]
    public class ExerciseTraningsheet
    {

        public int NumbersOfSet { get; set; }

        public int NumbersIteration { get; set; }


        [ForeignKey("ExerciseID")]
        public long ExerciseID { get; set; }

        public Exercise.Exercise Exercise { get; set; }

        [ForeignKey("TrainingsheetID")]
        public long TrainingsheetID { get; set; }
        public TrainingSheet.TrainingSheet Trainingsheet { get; set; }
    }
}
