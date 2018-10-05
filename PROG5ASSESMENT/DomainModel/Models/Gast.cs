using System.ComponentModel.DataAnnotations;

namespace DomainModel.Models {
    
    public class Gast {

        // Public constructor
        public Gast() { 
            
        }

        // Primary
        [Key]
        public          int         GastId          { get; set; }
        [Required, Display(Name = "Voornaam")]
        public          string      Voornaam        { get; set; }
        [Display(Name = "Tussenvoegsel")]
        public          string      TussenVoegsel   { get; set; }
        [Required, Display(Name = "Achternaam")]
        public          string      Achternaam      { get; set; }

        // Foreign
        [Required, Display(Name = "Reservering")]
        public virtual  Reservering Reservering     { get; set; }

    }

}
