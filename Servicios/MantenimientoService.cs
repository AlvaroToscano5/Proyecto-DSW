using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using DAO;

namespace Servicios
{
   public class MantenimientoService {
        mantenimientoDAO mantenimiento = new mantenimientoDAO();
        equipoDAO equipo = new equipoDAO();

        public List<MobiliarioEntity> listarMobiliario()  {
            return mantenimiento.listarMobiliario();
        }

        public List<EquipoEntity> listarEquipo()
        {
            return equipo.listar();
        }
    }
}
