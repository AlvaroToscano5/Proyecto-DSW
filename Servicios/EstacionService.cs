using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAO;

namespace Servicios {
    public class EstacionService {
        estacionDAO estacion = new estacionDAO();

        public List<EstacionEntity> listarEstacion() {
            return estacion.listarEstacion();
        }
    }
}
