using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAO;

namespace Servicios {
    public class ProveedorService {
        proveedorDAO proveedor = new proveedorDAO();

        public List<ProveedorEntity> listar() {
            return proveedor.listar();
        }

        public string generarCodigo() {
            return proveedor.generarCodigo();
        }

        public string formatoCuenta(string cuenta) {
            return proveedor.formatoCuenta(cuenta);
        }

        public string registrar(ProveedorEntity pro) {
            return proveedor.registrar(pro);
        }

        public string actualizar(ProveedorEntity pro) {
            return proveedor.actualizar(pro);
        }
    }
}
