using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public class RecargaEntity {
        public string codigo { get; set; }
        public decimal monto { get; set; }
        public DateTime fechaReg { get; set; }
        public string dni { get; set; }
        public string usuario { get; set; }
    }
}
