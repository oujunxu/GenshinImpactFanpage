using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLibrary.Models
{
    public class CharacterModel
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)] 
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [RegularExpression(@"^[0-9]( {1,}).*[A-Za-z]*$")]
        [Required(ErrorMessage = "Must contain a number and characters.")]
        public string Rarity { get; set; }

        [RegularExpression(@"^(.*[A-Za-z])( {1,}).*[0-9]*$")]
        [StringLength(50)]
        [Required(ErrorMessage = "Must contain month and date.")]
        public string Birthday { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Allegiance/Alliance is required.")]
        public string Allegiance { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Must contain: Cryo/Pyro/Anemo/Electro/Geo/Hydro.")]
        public string Element { get; set; }

        [StringLength(1024, MinimumLength = 10)]
        [Required(ErrorMessage = "Image is required.")]
        public string Image { get; set; }

        [StringLength(1024, MinimumLength = 50)]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

    }
}
