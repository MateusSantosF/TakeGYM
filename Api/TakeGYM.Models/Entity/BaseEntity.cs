using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TakeGYM.Models.Entity
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }
    }
}
