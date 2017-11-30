using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAO;

namespace Servicios {
    public class EstaticosService {
        estaticosDAO estaticos = new estaticosDAO();

        public List<EstaticosEntity> estadosReclamos() {
            return estaticos.estadosReclamos();
        }

        public List<EstaticosEntity> generos() {
            return estaticos.generos();
        }

        public List<EstaticosEntity> empleados() {
            return estaticos.empleados();
        }
    }
}
