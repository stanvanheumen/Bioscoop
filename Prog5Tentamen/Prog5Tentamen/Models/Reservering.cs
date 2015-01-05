using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prog5Tentamen.Models {

    public class Reservering {

        public Reservering() {
            Gasten = new List<Gast>();
        }

        [Key]
        public          int                 ReserveringId           { get; set; }
        [Required]
        public          int                 GereserveerdePlekken    { get; set; }
        [Required]
        public          decimal             Totaalprijs             { get; set; }
        [Required]
        public          string              Factuuradres            { get; set; }
        [Required]
        public          string              Bankrekeningnummer      { get; set; }
        [Required]
        public virtual  Film                Film                    { get; set; } 

        public virtual ICollection<Gast>    Gasten                  { get; set; }

    }

}