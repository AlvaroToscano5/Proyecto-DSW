using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAO;

namespace Servicios {
    public class UsuarioService {
        usuarioDAO usuario = new usuarioDAO();

        public string iniciarSesion(string user, string contraseña) {
            return usuario.iniciarSesion(user, contraseña);
        }

        public string generarCodigo() {
            return usuario.generarCodigo();
        }

        public string generarUsuario(string nombre, string apellido) {
            return usuario.generarUsuario(nombre, apellido);
        }

        public List<UsuarioEntity> listar() {
            return usuario.listar();
        }

        public string registrar(UsuarioEntity usu) {
            return usuario.registrar(usu);
        }

        public string actualizar(UsuarioEntity usu) {
            return usuario.actualizar(usu);
        }

        public string actualizarTipo(UsuarioEntity usu) {
            return usuario.actualizarTipo(usu);
        }

        public string actualizarDatos(UsuarioEntity usu) {
            return usuario.actualizarDatos(usu);
        }
    }
}
