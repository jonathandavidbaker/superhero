using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.DATA.EF
{
    public class LocationMetadata
    {
        [Required(ErrorMessage = "* Required")]
        [StringLength(150, ErrorMessage = "* 150 characters or fewer")]
        public string Address { get; set; }

        [Required(ErrorMessage = "* Required")]
        [StringLength(50, ErrorMessage = "* 50 characters or fewer")]
        public string City { get; set; }

        [Required(ErrorMessage = "* Required")]
        [StringLength(50, ErrorMessage = "* 50 characters or fewer")]
        public string State { get; set; }

        [StringLength(50, ErrorMessage = "* 50 characters or fewer")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Planet { get; set; }
    }

    [MetadataType(typeof(LocationMetadata))]
    public partial class Location { }
}
