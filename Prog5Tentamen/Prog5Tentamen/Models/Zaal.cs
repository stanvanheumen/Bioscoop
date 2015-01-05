using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prog5Tentamen.Models {

    public class Zaal {

        public Zaal() {
            Films = new List<Film>();
        }

        [Key]
        public          int                 ZaalId          { get; set; }
        [Required]
        public          int                 Zitplaatsen     { get; set; }
        [Required]
        public          string              Naam            { get; set; }

        public virtual  ICollection<Film>   Films           { get; set; }

    }

}