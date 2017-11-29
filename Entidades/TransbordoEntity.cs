using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public class TransbordoEntity {
        public int cantidad { get; set; }
        public DateTime hora { get; set; }
        public string codigoUsuario { get; set; }
        public int codigoCobranza { get; set; }
    }
}
