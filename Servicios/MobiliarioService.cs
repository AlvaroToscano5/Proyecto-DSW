using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAO;

namespace Servicios {
    public class MobiliarioService {
        mobiliarioDAO mobiliario = new mobiliarioDAO();

        public string generarCodigo() {
            return mobiliario.generarCodigo();
        }

        public List<MobiliarioEntity> listar() {
            return mobiliario.listar();
        }

        public string registrar(MobiliarioEntity mob) {
            return mobiliario.registrar(mob);
        }

        public string actualizar(MobiliarioEntity mob) {
            return mobiliario.actualizar(mob);
        }
    }
}
