using System.ComponentModel.DataAnnotations;

namespace projet_dotnet.Models
{
public class Societe
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Le nom de la société est requis.")]
        [Display(Name = "Nom")]
        public string? Lib { get; set; }

        [Required(ErrorMessage = "L'adreese de la société est requis.")]
        [Display(Name = "Adresse")]
        public string? Adresse { get; set; }

        [Required(ErrorMessage = "Le  numero de telephone est requis.")]
        [Display(Name = "Téléphone")]
        [DataType(DataType.PhoneNumber)]
        public string? Tel { get; set; }
    }

}

