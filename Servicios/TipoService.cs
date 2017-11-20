using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAO;

namespace Servicios {
    public class TipoService {
        tipoDAO tipo = new tipoDAO();

        public List<TipoEntity> listarTipoEmpleado() {
            return tipo.listarTipoEmpleado();
        }

        public List<TipoEntity> listarTipoRuta() {
            return tipo.listarTipoRuta();
        }

        public List<TipoEntity> listarTipoEqMob() {
            return tipo.listarTipoEqMob();
        }

        public List<TipoEntity> listarTipoServicio() {
            return tipo.listarTipoServicio();
        }

        public List<TipoEntity> listarTipoUsuario() {
            return tipo.listarTipoUsuario();
        }
    }
}
