using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAO;

namespace Servicios {
    public class AreaService {
        areaDAO area = new areaDAO();

        public List<AreaEntity> listarArea() {
            return area.listarArea();
        }
    }
}
