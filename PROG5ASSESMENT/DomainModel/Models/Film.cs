using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Models {
    
    public class Film {

        // Constructor
        public Film() {
            Reserveringen = new List<Reservering>();
        }

        // Primary
        [Key]
        public          int                         FilmId              { get; set; }
        [Required, Display(Name = "Film")]
        public          string                      Naam                { get; set; }
        [Required, Display(Name = "Prijs")]
        public          decimal                     Prijs               { get; set; }
        [Required, Display(Name = "Starttijd")]
        public          DateTime                    StartDatumMetTijd   { get; set; }
        [Required, Display(Name = "Eindtijd")]
        public          DateTime                    EindDatumMetTijd    { get; set; }

        // Foreign
        [Required, Display(Name = "Zaal")]
        public virtual  Zaal                        Zaal                { get; set; }
        [Display(Name = "Reserveringen")]
        public virtual  ICollection<Reservering>    Reserveringen       { get; set; }

    }

}
