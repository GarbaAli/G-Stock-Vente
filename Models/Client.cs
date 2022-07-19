using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Models
{
    public class Client
    {
        [Key]
        public int clientId { get; set; }

        [MinLength(3)]
        [DisplayName("Code Client")]
        public string codeClt { get; set; }

        [MinLength(3)]
        [Required(ErrorMessage = "Le Nom du client est requis.")]
        [DisplayName("Nom et Prenom du Client")]
        public string nomClt { get; set; }

        public string emailClt { get; set; }

        [MaxLength(9)]
        [MinLength(6)]
        [Required(ErrorMessage = "Le Contact du client est requis.")]
        [DisplayName("Phone Client")]
        public string phoneClt { get; set; }
        public string postalClt { get; set; }
        public string paysClt { get; set; }
        public string villeClt { get; set; }
        public bool statutClt { get; set; }
    }
}
