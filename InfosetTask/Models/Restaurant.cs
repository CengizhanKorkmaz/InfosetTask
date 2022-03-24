using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace InfosetTask.Models
{
    public class Restaurant
    {
        [Key]
        public int id { get; set; }
        [StringLength(100)]
        public string name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        [AllowNull]
        public double distance { get; set; }
    }
}
