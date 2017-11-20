using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class usuarioDAO {
        conexionDAO cn = new conexionDAO();

        public string generarCodigo() {
            DataTable dt = new DataTable();
            string m = "";
            string codigo = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarUsuario", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }

            if (dt.Rows.Count < 9) {
                codigo = "U00000000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 99) {
                codigo = "U0000000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 999) {
                codigo = "U000000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 9999) {
                codigo = "U00000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 99999) {
                codigo = "U0000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 999999) {
                codigo = "U000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 9999999) {
                codigo = "U00" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 99999999) {
                codigo = "U0" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 999999999) {
                codigo = "U" + (dt.Rows.Count + 1).ToString();
            } else {
                codigo = "";
            }

            return codigo;
        }

        public string generarUsuario(string nombre, string apellido) {
            string usuario = "";

            char espacio = ' ';
            int inicio = 0;
            int final = apellido.LastIndexOf(espacio);
            int total = final - inicio + 1;

            return usuario = nombre.Substring(0, 1).ToLower() + apellido.Substring(inicio, total).ToLower().Trim();
        }

        public List<UsuarioEntity> listar() {
            string m = "";
            List<UsuarioEntity> lista = new List<UsuarioEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarUsuario", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    UsuarioEntity reg = new UsuarioEntity();
                    reg.codigo = dr[0].ToString();
                    reg.dni = dr[1].ToString();
                    reg.nombre = dr[2].ToString();
                    reg.apellidos = dr[3].ToString();
                    reg.sexo = dr[4].ToString();
                    reg.edad = Convert.ToInt32(dr[5]);
                    reg.nacionalidad = dr[6].ToString();
                    reg.usuario = dr[7].ToString();
                    reg.contraseña = dr[8].ToString();
                    reg.saldo = Convert.ToDouble(dr[9]);
                    reg.fechaReg = dr[10].ToString();
                    reg.fechaAct = dr[11].ToString();
                    reg.tipo = dr[12].ToString();
                    reg.estado = dr[13].ToString();
                    /*reg.huella = (byte[])dr[14];*/
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }

        public string registrar(UsuarioEntity usu) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_RegistrarUsuario", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod", usu.codigo);
                cmd.Parameters.AddWithValue("@dni", usu.dni);
                cmd.Parameters.AddWithValue("@nom", usu.nombre);
                cmd.Parameters.AddWithValue("@ape", usu.apellidos);
                cmd.Parameters.AddWithValue("@sex", usu.sexo);
                cmd.Parameters.AddWithValue("@eda", usu.edad);
                cmd.Parameters.AddWithValue("@nac", usu.nacionalidad);
                cmd.Parameters.AddWithValue("@usu", usu.usuario);
                cmd.Parameters.AddWithValue("@con", usu.contraseña);
                cmd.Parameters.AddWithValue("@sal", usu.saldo);
                cmd.Parameters.AddWithValue("@frg", usu.fechaReg);
                cmd.Parameters.AddWithValue("@fac", usu.fechaAct);
                cmd.Parameters.AddWithValue("@tiu", usu.tipo);
                cmd.Parameters.AddWithValue("@est", usu.estado);
                /*cmd.Parameters.AddWithValue("@hue", usu.huella);*/

                cmd.ExecuteNonQuery();

                m = "Registro Agregado";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return m;
        }

        public string actualizar(UsuarioEntity usu) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ActualizarUsuario", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nom", usu.nombre);
                cmd.Parameters.AddWithValue("@ape", usu.apellidos);
                cmd.Parameters.AddWithValue("@sex", usu.sexo);
                cmd.Parameters.AddWithValue("@eda", usu.edad);
                cmd.Parameters.AddWithValue("@nac", usu.nacionalidad);
                cmd.Parameters.AddWithValue("@fac", usu.fechaAct);
                cmd.Parameters.AddWithValue("@tiu", usu.tipo);
                cmd.Parameters.AddWithValue("@est", usu.estado);
                cmd.Parameters.AddWithValue("@cod", usu.codigo);

                cmd.ExecuteNonQuery();

                m = "Registro Actualizado";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return m;
        }

        public string actualizarTipo(UsuarioEntity usu) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ActualizarTipo", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tiu", usu.tipo);
                cmd.Parameters.AddWithValue("@cod", usu.codigo);

                cmd.ExecuteNonQuery();

                m = "Tipo de Usuario Actualizado";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return m;
        }
    }
}
