using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SuperHero.DATA;

namespace SuperHero.UI.Models
{
    public class CalendarViewModel
    {
        [Key]
        public int CourseID { get; set; }

        [Display(Name="Class")]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name="Instructor")]
        public string Hero { get; set; }

    }
}