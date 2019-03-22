using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.DATA.EF
{
    public class CharacterMetadata
    {
        [Required(ErrorMessage = "* Required")]
        [StringLength(100, ErrorMessage = "* 100 characters or fewer")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "* 100 characters or fewer")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Alias { get; set; }

        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Description { get; set; }

        [StringLength(100, ErrorMessage = "* 100 characters or fewer")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Occupation { get; set; }

        [Display(Name = "Hero?")]
        public bool IsHero { get; set; }

        [StringLength(110, ErrorMessage = "* 110 characters or fewer")]
        [Display(Name="Image")]
        public string CharacterImage { get; set; }

        [Display(Name = "Active?")]
        public bool IsActive { get; set; }
    }

    [MetadataType(typeof(CharacterMetadata))]
    public partial class Character { }

}
