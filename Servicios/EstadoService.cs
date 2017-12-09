using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAO;

namespace Servicios {
    public class EstadoService {
        estadoDAO estado = new estadoDAO();

        public List<EstadoEntity> listarEstadoEmpUsu() {
            return estado.listarEstadoEmpUsu();
        }

        public List<EstadoEntity> listarEstadoMobEquip() {
            return estado.listarEstadoMobEquip();
        }
        public List<EstadoEntity> listarEstadoOperativo()
        {
            return estado.listarEstadoOperativo();
        }

    }
}
