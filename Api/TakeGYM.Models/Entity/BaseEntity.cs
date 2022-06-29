using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Newtonsoft.Json;

namespace TakeGYM.Models.Entity
{
    public class BaseEntity
    {
        [Key]
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
