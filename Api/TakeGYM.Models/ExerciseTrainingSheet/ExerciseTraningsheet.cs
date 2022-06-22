using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using TakeGYM.Models.Entity;

namespace TakeGYM.Models.ExerciseTrainingSheet
{
    [Table("Exercise_Trainingsheet")]
    public class ExerciseTraningsheet: BaseEntity
    {

        public int NumbersOfSet { get; set; }

        public int NumbersIteration { get; set; }

        [ForeignKey("ExerciseId")]
        public string ExerciseId { get; set; }

        public Exercise.Exercise Exercise { get; set; }

        [ForeignKey("TrainingsheetId")]
        public string TrainingsheetId { get; set; }

        public TrainingSheet.TrainingSheet Trainingsheet { get; set; }
    }
}
