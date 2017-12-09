using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAO;

namespace Servicios {
    public class EmpleadoService {
        empleadoDAO empleado = new empleadoDAO();

        public string iniciarSesion(string usuario, string contraseña) {
            return empleado.iniciarSesion(usuario, contraseña);
        }

        public string generarCodigo() {
            return empleado.generarCodigo();
        }

        public string generarUsuario(string nombre, string apellido) {
            return empleado.generarUsuario(nombre, apellido);
        }

        public List<EmpleadoEntity> listar() {
            return empleado.listar();
        }

        public string registrar(EmpleadoEntity emp) {
            return empleado.registrar(emp);
        }

        public string actualizar(EmpleadoEntity emp) {
            return empleado.actualizar(emp);
        }

        public string actualizarDatos(EmpleadoEntity emp) {
            return empleado.actualizarDatos(emp);
        }

        public List<EmpleadoEntity> reporteEmpleado(string tip, string est)
        {
            return empleado.reporteEmpleado(tip, est);
        }
    }
}
