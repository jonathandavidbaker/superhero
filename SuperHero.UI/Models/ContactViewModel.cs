using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperHero.UI.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "* Required")]
        [UIHint("MultilineText")]
        public string Message { get; set; }
    }
}