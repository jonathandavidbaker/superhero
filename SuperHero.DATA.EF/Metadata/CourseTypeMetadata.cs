using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.DATA.EF
{
    public class CourseTypeMetadata
    {
        [Required(ErrorMessage = "* Required")]
        [StringLength(100, ErrorMessage = "* 100 characters or fewer")]
        public string Name { get; set; }

        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Description { get; set; }
    }

    [MetadataType(typeof(CourseTypeMetadata))]
    public partial class CourseType { }
}
