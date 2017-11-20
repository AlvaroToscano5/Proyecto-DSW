using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAO;

namespace Servicios {
    public class PaisService {
        paisDAO pais = new paisDAO();

        public List<PaisEntity> listarPais() {
            return pais.listarPais();
        }
    }
}
