using System.ComponentModel.DataAnnotations;

namespace projet_dotnet.Models
{
    public class Etudiant
    {

    
        public int ID { get; set; }

        [Required(ErrorMessage = "Le nom de l'étudiant est requis.")]
        [Display(Name = "Nom")]
        public string? Nom { get; set; }

        [Required(ErrorMessage = "Le prénom de l'étudiant est requis.")]
        [Display(Name = "Prénom")]
        public string? Prenom { get; set; }

        [Display(Name = "Date de Naissance")]
        [DataType(DataType.Date)]
        public DateTime DateNaiss { get; set; }
    }

}

