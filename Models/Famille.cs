using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Models
{
    public class Famille
    {
        [Key]
        public int familleId { get; set; }

        [Required(ErrorMessage ="Le code la famille requise")]
        [MaxLength(ErrorMessage ="Le code ne dois pas depasser 8 caracteres")]
        public string codeFamille { get; set; }
        [Required(ErrorMessage ="Le libelle est requis")]
        public string libelleFamille { get; set; }
        public bool statusFamille { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
