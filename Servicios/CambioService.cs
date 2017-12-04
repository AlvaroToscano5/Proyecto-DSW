using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using DAO;

namespace Servicios {
    public class CambioService {
        cambioDAO cambio = new cambioDAO();
        equipoDAO equipo = new equipoDAO();

        public List<MobiliarioEntity> listarMobiliario() {
            return cambio.listarMobiliarioCambio();
        }

        public List<EquipoEntity> listarEquipo() {
            return equipo.listar();
        }
    }
}
