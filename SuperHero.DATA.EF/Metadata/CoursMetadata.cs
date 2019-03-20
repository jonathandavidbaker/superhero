using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.DATA.EF
{
    public class CoursMetadata
    {
        [Required(ErrorMessage = "* Required")]
        [StringLength(100, ErrorMessage = "* 100 characters or fewer")]
        public string Name { get; set; }

        [UIHint("MultilineText")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "* Required")]
        public System.DateTime Date { get; set; }
    }

    [MetadataType(typeof(CoursMetadata))]
    public partial class Cours { }
}
