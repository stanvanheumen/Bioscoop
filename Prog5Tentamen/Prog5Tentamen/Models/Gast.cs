using System.ComponentModel.DataAnnotations;

namespace Prog5Tentamen.Models {

    public class Gast {

        [Key]
        public          int             GastId          { get; set; }
        [Required]
        public          string          Voornaam        { get; set; }

        public          string          Tussenvoegsel   { get; set; }
        [Required]
        public          string          Achternaam      { get; set; }
        [Required]
        public virtual  Reservering     Reservering     { get; set; }

    }

}