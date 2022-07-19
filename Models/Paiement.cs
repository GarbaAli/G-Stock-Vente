using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Models
{
    public class Paiement
    {
        [Key]
        public int paiementId { get; set; }

        [Required(ErrorMessage ="Libelle de paiement requis!")]
        public string libellePaiement { get; set; }

        [Required (ErrorMessage ="Le code de paiement est requis!")]
        [MaxLength (ErrorMessage ="Le code ne peut depasser 5 caracteres")]
        public string cdepaiement { get; set; }

        public bool statutPaiement { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }
}
