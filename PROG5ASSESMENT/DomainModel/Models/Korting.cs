using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Models {
    
    public class Korting {
        
        // Constructor
        public Korting() {
            Reserveringen = new List<Reservering>();
        }

        // Primary
        [Key]
        public          int                         KortingId       { get; set; }
        [Required, Display(Name = "Kortingcode")]
        public          string                      KortingsCode    { get; set; }
        [Required, Display(Name = "Korting")]
        public          decimal                     Kortingsprijs   { get; set; }
        [Required, Display(Name = "Startdatum")]
        public          DateTime                    StartDatum      { get; set; }
        [Required, Display(Name = "Einddatum")]
        public          DateTime                    EindDatum       { get; set; }

        // Foreign
        [Display(Name = "Reserveringen")]
        public virtual  ICollection<Reservering>    Reserveringen   { get; set; }

    }

}
