using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAO;

namespace Servicios {
    public class TarjetasService {
        tarjetaDAO tarjeta = new tarjetaDAO();

        public List<TarjetasEntity> listarVisa() {
            return tarjeta.listarVisa();
        }

        public List<TarjetasEntity> listarMaster() {
            return tarjeta.listarMaster();
        }
    }
}
