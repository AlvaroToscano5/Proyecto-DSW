using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public class TarjetasEntity {
        public string codigo { get; set; }
        public string numero { get; set; }
        public string titular { get; set; }
        public DateTime fecha { get; set; }
        public string cvc { get; set; }
        public string tipo { get; set; }
        public string numeroDoc { get; set; }
    }
}
