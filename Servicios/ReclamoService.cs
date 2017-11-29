using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Entidades;
using DAO;

namespace Servicios {
  public  class ReclamoService {
        reclamoDAO reclamo = new reclamoDAO();

        public string generar(ReclamoEntity rec) {
            return reclamo.generar(rec);
        }

        public List<ReclamoEntity> listar() {
            return reclamo.listarReclamo();
        }

    }
}
