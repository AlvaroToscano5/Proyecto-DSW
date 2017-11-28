using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CobranzaEntity {
        public string codigo { get; set; }
        public int cantidad { get; set; }
        public string fechaReg { get; set; }
        public decimal monto { get; set; }
        public string tipo { get; set; }
    }
}
