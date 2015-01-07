using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Models {
    
    public class Zaal {

        // Constructor
        public Zaal() {
            Films = new List<Film>();
        }

        // Primary
        [Key]
        public          int                 ZaalId      { get; set; }
        [Required, Display(Name = "Zitplaatsen")]
        public          int                 Zitplaatsen { get; set; }
        [Required, Display(Name = "Zaal")]
        public          string              Naam        { get; set; }

        // Foreign
        [Display(Name = "Films")]
        public virtual  ICollection<Film>   Films       { get; set; }

    }

}
