using System.ComponentModel.DataAnnotations;

namespace projet_dotnet.Models
{
    public class Enseignant
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Le nom de l'enseignant est requis.")]
        [Display(Name = "Nom")]
        public string? Nom {  get; set; }

        [Required(ErrorMessage = "Le Prenom de l'enseignant est requis.")]
        [Display(Name = "Prenom")]
        public string? Prenom { get; set; }

        public string NomPrenom { get { return Nom + " " + Prenom; } }


        }
}
