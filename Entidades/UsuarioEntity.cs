using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public class UsuarioEntity {
        public string codigo { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string sexo { get; set; }
        public int edad { get; set; }
        public string nacionalidad { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public decimal saldo { get; set; }
        public DateTime fechaReg { get; set; }
        public DateTime fechaAct { get; set; }
        public string tipo { get; set; }
        public string estado { get; set; }
        public byte[] huella { get; set; }
    }
}
