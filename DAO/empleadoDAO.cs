 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class empleadoDAO {
        conexionDAO cn = new conexionDAO();

        public string iniciarSesion(string usuario, string contraseña) {
            DataTable dt = new DataTable();
            string m = "";
            string acceso = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_IniciarSesion", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USU", usuario);
                cmd.Parameters.AddWithValue("@PSS", contraseña);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }

            DataTable emp = credenciales(usuario, contraseña);

            if (dt.Rows.Count == 1) {
                if (dt.Rows[0][0].ToString() == "EEU01") {
                    if (dt.Rows[0][1].ToString() == emp.Rows[0][1].ToString()) {
                        if (dt.Rows[0][2].ToString() == emp.Rows[0][2].ToString()) {
                            switch (emp.Rows[0][2].ToString()) {
                                case "TE001": acceso = "Administrador"; break;
                                case "TE002": acceso = "GerenteGeneral"; break;
                                case "TE003": acceso = "AsistenteRRHH"; break;
                                case "TE004": acceso = "GerenteRRHH"; break;
                                case "TE005": acceso = "AsistenteDC"; break;
                                case "TE006": acceso = "GerenteDC"; break;
                                case "TE007": acceso = "AsistenteST"; break;
                                case "TE008": acceso = "GerenteST"; break;
                                case "TE009": acceso = "AsistenteCAU"; break;
                                case "TE010": acceso = "GerenteCAU"; break;
                                case "TE011": acceso = "Cajero"; break;
                                case "TE012": acceso = "EncargadoP"; break;
                            }
                        } else { acceso = "Error"; }
                    } else { acceso = "Error"; }
                } else { acceso = "Inactivo"; }
            } else { acceso = "Error"; }

            return acceso;
        }

        public DataTable credenciales(string usuario, String contraseña) {
            DataTable dt = new DataTable();
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_IniciarSesion", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USU", usuario);
                cmd.Parameters.AddWithValue("@PSS", contraseña);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }

            return dt;
        }

        public string generarCodigo() {
            DataTable dt = new DataTable();
            string m = "";
            string codigo = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarEmpleado", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }

            if (dt.Rows.Count < 9) {
                codigo = "E00000000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 99) {
                codigo = "E0000000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 999) {
                codigo = "E000000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 9999) {
                codigo = "E00000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 99999) {
                codigo = "E0000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 999999) {
                codigo = "E000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 9999999) {
                codigo = "E00" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 99999999) {
                codigo = "E0" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 999999999) {
                codigo = "E" + (dt.Rows.Count + 1).ToString();
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

        public List<EmpleadoEntity> listar() {
            string m = "";
            List<EmpleadoEntity> lista = new List<EmpleadoEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarEmpleado", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    EmpleadoEntity reg = new EmpleadoEntity();
                    reg.codigo = dr[0].ToString();
                    reg.dni = dr[1].ToString();
                    reg.nombre = dr[2].ToString();
                    reg.apellidos = dr[3].ToString();
                    reg.sexo = dr[4].ToString();
                    reg.correo = dr[5].ToString();
                    reg.edad = Convert.ToInt32(dr[6]);
                    reg.direccion = dr[7].ToString();
                    reg.telefono = dr[8].ToString();
                    reg.usuario = dr[9].ToString();
                    reg.contraseña = dr[10].ToString();
                    reg.fechaReg = Convert.ToDateTime(dr[11]);
                    reg.fechaAct = Convert.ToDateTime(dr[12]);
                    reg.tipo = dr[13].ToString();
                    reg.estado = dr[14].ToString();
                    reg.estacion = dr[15].ToString();
                    reg.area = dr[16].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }

        public string registrar(EmpleadoEntity emp) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_RegistrarEmpleado", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod", emp.codigo);
                cmd.Parameters.AddWithValue("@dni", emp.dni);
                cmd.Parameters.AddWithValue("@nom", emp.nombre);
                cmd.Parameters.AddWithValue("@ape", emp.apellidos);
                cmd.Parameters.AddWithValue("@sex", emp.sexo);
                cmd.Parameters.AddWithValue("@cor", emp.correo);
                cmd.Parameters.AddWithValue("@eda", emp.edad);
                cmd.Parameters.AddWithValue("@dir", emp.direccion);
                cmd.Parameters.AddWithValue("@tel", emp.telefono);
                cmd.Parameters.AddWithValue("@usu", emp.usuario);
                cmd.Parameters.AddWithValue("@con", emp.contraseña);
                cmd.Parameters.AddWithValue("@frg", emp.fechaReg);
                cmd.Parameters.AddWithValue("@fac", emp.fechaAct);
                cmd.Parameters.AddWithValue("@tem", emp.tipo);
                cmd.Parameters.AddWithValue("@teu", emp.estado);
                cmd.Parameters.AddWithValue("@est", emp.estacion);
                cmd.Parameters.AddWithValue("@are", emp.area);

                cmd.ExecuteNonQuery();

                m = "Registro Agregado";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return m;
        }

        public string actualizar(EmpleadoEntity emp) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ActualizarEmpleado", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dni", emp.dni);
                cmd.Parameters.AddWithValue("@nom", emp.nombre);
                cmd.Parameters.AddWithValue("@ape", emp.apellidos);
                cmd.Parameters.AddWithValue("@sex", emp.sexo);
                cmd.Parameters.AddWithValue("@cor", emp.correo);
                cmd.Parameters.AddWithValue("@eda", emp.edad);
                cmd.Parameters.AddWithValue("@dir", emp.direccion);
                cmd.Parameters.AddWithValue("@tel", emp.telefono);
                cmd.Parameters.AddWithValue("@fac", emp.fechaAct);
                cmd.Parameters.AddWithValue("@tem", emp.tipo);
                cmd.Parameters.AddWithValue("@teu", emp.estado);
                cmd.Parameters.AddWithValue("@est", emp.estacion);
                cmd.Parameters.AddWithValue("@are", emp.area);
                cmd.Parameters.AddWithValue("@cod", emp.codigo);

                cmd.ExecuteNonQuery();

                m = "Registro Actualizado";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return m;
        }

        public string actualizarDatos(EmpleadoEntity emp) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ActualizarDatos", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eda", emp.edad);
                cmd.Parameters.AddWithValue("@dir", emp.direccion);
                cmd.Parameters.AddWithValue("@tel", emp.telefono);
                cmd.Parameters.AddWithValue("@usu", emp.usuario);
                cmd.Parameters.AddWithValue("@pss", emp.contraseña);
                cmd.Parameters.AddWithValue("@fac", emp.fechaAct);
                cmd.Parameters.AddWithValue("@cod", emp.codigo);

                cmd.ExecuteNonQuery();

                m = "Registro Actualizado";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return m;
        }
    }
}
