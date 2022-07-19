using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Models
{
    public class General
    {
        [Key]
        public int reference { get; set; }
        public string appNom{ get; set; }
        public string devise { get; set; }
        public int alerteJour { get; set; }
        public DateTime dte_creation { get; set; }
        public DateTime last_modification { get; set; }

    }
}
