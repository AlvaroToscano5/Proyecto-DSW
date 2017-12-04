using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAO;

namespace Servicios {
    public class RutaService {
        RutaDAO ruta = new RutaDAO();

        public string generarCodigo() {
            return ruta.generarCodigo();
        }

        public List<RutaEntity> listar() {
            return ruta.listar();
        }

        public string registrar(RutaEntity ru) {
            return ruta.registrar(ru);
        }

        
    }
}
