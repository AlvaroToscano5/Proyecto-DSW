using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public class ReclamoEntity {
        public string codigo { get; set; }
        public string dni{ get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipo{ get; set; }
        public DateTime fechaReg { get; set; }
        public DateTime fechaAct { get; set; }
        public string estado { get; set; }
        public string descripcion { get; set; }
        public string usuario { get; set; }
        public string estacion { get; set; }
        public string empleado { get; set; }
    }
}
