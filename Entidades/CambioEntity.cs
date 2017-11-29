using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public class CambioEntity {
        public string codigo { get; set; }
        public string estado { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaReg { get; set; }
        public DateTime fechaAct { get; set; }
        public string empleado { get; set; }
    }
}
