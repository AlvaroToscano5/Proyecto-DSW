using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAO;

namespace Servicios {
    public class EquipoService {
        equipoDAO equipo = new equipoDAO();

        public string generarCodigo() {
            return equipo.generarCodigo();
        }

        public List<EquipoEntity> listar() {
            return equipo.listar();
        }

        public string registrar(EquipoEntity equ) {
            return equipo.registrar(equ);
        }

        public string actualizar(EquipoEntity equ) {
            return equipo.actualizar(equ);
        }
    }
}
