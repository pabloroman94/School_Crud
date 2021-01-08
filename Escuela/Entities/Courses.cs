using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCrud.Entities
{
    public class Courses
    {
        [Key]
        public int IdCourse { get; set; }
        public string NameCourse { get; set; }
    }
}
