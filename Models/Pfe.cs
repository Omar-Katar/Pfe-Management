using System.ComponentModel.DataAnnotations;

namespace projet_dotnet.Models
{
    public class Pfe
    {

        [Key]
        public int PfeId { get; set; }

        [Required(ErrorMessage = "Le titre est requis.")]
        [Display(Name = "Titre")]
        public string? Titre { get; set; }

        [Display(Name = "Description")]
        public string? Desc { get; set; }

        [Required(ErrorMessage = "La date de début est requise.")]
        [Display(Name = "Date de début")]
        [DataType(DataType.Date)]
        public DateTime DateD { get; set; }

        [Required(ErrorMessage = "La date de fin est requise.")]
        [Display(Name = "Date de fin")]
        [DataType(DataType.Date)]
        public DateTime DateF { get; set; }

        [Required(ErrorMessage = "L'ID de l'encadrant est requis.")]
        [Display(Name = "ID de l'encadrant")]
        public int EncadrantID { get; set; }

        [Required(ErrorMessage = "L'ID de la société est requis.")]
        [Display(Name = "ID de la société")]
        public int SocieteID { get; set; }

        // Navigation properties (propriétés de navigation)
        public virtual Enseignant? Encadrant { get; set; }
        public virtual Societe? Societe { get; set; }
    }

}

