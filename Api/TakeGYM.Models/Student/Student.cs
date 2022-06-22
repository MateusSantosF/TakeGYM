﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using TakeGYM.Models.Entity;
using TakeGYM.Models.Structures;

namespace TakeGYM.Models.Student
{
    [Table("Student")]
    public class Student: BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        [MaxLength(14, ErrorMessage = "CPF LENGTH OUT OF BOUNDS")]
        public string CPF { get; set; }

        [MaxLength(9, ErrorMessage = "CEP LENGTH OUT OF BOUNDS")]
        public string CEP { get; set; }

        public string Street { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        [MinLength(8, ErrorMessage = "Very small Password")]
        public string Password { get; set; }

        [ForeignKey("TeacherID")]
        public string TeacherID { get; set; }

        public virtual Teacher.Teacher Teacher { get; set; }

        public bool HasPersonal { get; set; }

        [Column("PersonalSchedule")]
        public Schedule PersonalSchedule { get; set; }
    }
}
