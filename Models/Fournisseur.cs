using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Models
{
    public class Fournisseur
    {
        [Key]
        public int FsseurId { get; set; }

        [MinLength(3)]
        [DisplayName("Code Fournisseur")]
        public string codeFsseur { get; set; }

        [MinLength(3)]
        [Required(ErrorMessage = "Le Nom du Fournisseur est requis.")]
        [DisplayName("Nom et Prenom du Fournisseur")]
        public string nomFsseur { get; set; }

        public string emailFsseur { get; set; }

        [MaxLength(9)]
        [MinLength(6)]
        [Required(ErrorMessage = "Le Contact du Fournisseur est requis.")]
        [DisplayName("Phone Fournisseur")]
        public string phoneFsseur { get; set; }
        public string postalFsseur { get; set; }
        public string paysFsseur { get; set; }
        public string villeFsseur { get; set; }
        public bool statutFsseur { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime createdFsseur { get; set; }
    }
}
