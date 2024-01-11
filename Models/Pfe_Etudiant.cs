using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_dotnet.Models
{
    public class Pfe_Etudiant
    {

            [Key]
            public int ID { get; set; }

            [ForeignKey("PFE")]
            [Required(ErrorMessage = "Choisir un Pfe.")]
            [Display(Name = "Libelle Pfe")]
            public int PfeId { get; set; }

            [ForeignKey ("Etudiant")]
            [Required(ErrorMessage = "Choisir un etudiant.")]
            [Display(Name = "Nom de l'etudaint")]
            public int EtudiantId { get; set; }

            // Propriétés de navigation vers les entités associées
            public virtual Pfe? Pfe { get; set; }
            public virtual Etudiant? Etudiant { get; set; }
        }

    }
