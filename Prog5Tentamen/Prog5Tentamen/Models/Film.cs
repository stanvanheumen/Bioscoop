using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prog5Tentamen.Models {

    public class Film {

        public Film() {
            Reserveringen = new List<Reservering>();
        }

        [Key]
        public          int                         FilmId              { get; set; }
        [Required]
        public          int                         TijdsduurinMinuten  { get; set; }
        [Required]
        public          string                      Naam                { get; set; }
        [Required]
        public          decimal                     Prijs               { get; set; }
        [Required]
        public          DateTime                    Datum               { get; set; }
        [Required]
        public virtual  Zaal                        Zaal                { get; set; }

        public virtual  ICollection<Reservering>    Reserveringen       { get; set; }

    }

}