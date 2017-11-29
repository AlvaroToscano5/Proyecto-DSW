using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public class ProveedorEntity {
        public string codigo { get; set; }
        public string ruc { get; set; }
        public string razSocial { get; set; }
        public string repLegal { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public DateTime fechaReg { get; set; }
        public DateTime fechaAct { get; set; }
        public string ctaBancaria { get; set; }
        public string pais { get; set; }
    }
}
