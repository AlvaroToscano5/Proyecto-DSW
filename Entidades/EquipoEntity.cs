﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public class EquipoEntity {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string placa { get; set; }
        public DateTime fechaReg { get; set; }
        public DateTime fechaAct { get; set; }
        public string proveedor { get; set; }
        public string tipo { get; set; }
        public string estado { get; set; }
    }
}
