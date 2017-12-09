using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAO;

namespace Servicios {
    public class RecargaService {
        recargaDAO recarga = new recargaDAO();

        public string generarCodigo() {
            return recarga.generarCodigo();
        }

        public string recargar(RecargaEntity rec) {
            return recarga.recargar(rec);
        }

        public List<RecargaEntity> reporteRecargas() {
            return recarga.reporteRecargas();
        }
    }
}
