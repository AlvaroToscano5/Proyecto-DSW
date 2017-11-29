using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public class RutaEntity {
        public string codigo { get; set; }
        public DateTime fechaReg { get; set; }
        public string turno { get; set; }
        public string placa { get; set; }
        public string horaPartida { get; set; }
        public string tipo { get; set; }
        public string empleado { get; set; }
        public string equipo { get; set; }
    }
}
