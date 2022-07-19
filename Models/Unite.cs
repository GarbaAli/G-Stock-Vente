using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Models
{
    public class Unite
    {
        [Key]
        public int uniteId { get; set; }

        [MaxLength(30)]
        [MinLength(3)]
        [Required(ErrorMessage ="Ce champs est requis.")]
        [DisplayName("Unité")]
        public string libelleUnite { get; set; }

        [MaxLength(5)]
        [Required(ErrorMessage ="Ce champs est requis.")]
        [DisplayName("Code de l'unité")]
        public string codeUnite { get; set; }
        public bool statutUnite { get; set; }
        public DateTime Created { get; set; }
        public DateTime updated { get; set; }
    }
}
