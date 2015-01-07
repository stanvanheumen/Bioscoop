using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Models {
    
    public class Reservering {

        // Constructor
        public Reservering() {
            Gasten = new List<Gast>();
        }

        // Primary
        [Key]
        public          int                 ReserveringId           { get; set; }
        [Required, Display(Name = "Totaalprijs")]
        public          decimal             Totaalprijs             { get; set; }
        [Required, Display(Name = "Factuuradres")]
        public          string              Factuuradres            { get; set; }
        [Required, Display(Name = "Bankrekeningnummer")]
        public          string              Bankrekeningnummer      { get; set; }
        [Display(Name = "Kortingscode")]
        public          string              KortingsCode            { get; set; }
        
        // Foreign
        [Required, Display(Name = "Film")]
        public virtual  Film                Film                    { get; set; }
        [Display(Name = "Korting")]
        public virtual  Korting             Korting                 { get; set; }
        [Display(Name = "Gasten")]
        public virtual  ICollection<Gast>   Gasten                  { get; set; }

    }

}
