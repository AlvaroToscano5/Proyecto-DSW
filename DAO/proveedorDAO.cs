using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class proveedorDAO {
        conexionDAO cn = new conexionDAO();

        public string generarCodigo() {
            DataTable dt = new DataTable();
            string m = "";
            string codigo = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarProveedor", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }

            if (dt.Rows.Count < 9) {
                codigo = "P00000000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 99) {
                codigo = "P0000000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 999) {
                codigo = "P000000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 9999) {
                codigo = "P00000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 99999) {
                codigo = "P0000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 999999) {
                codigo = "P000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 9999999) {
                codigo = "P00" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 99999999) {
                codigo = "P0" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 999999999) {
                codigo = "P" + (dt.Rows.Count + 1).ToString();
            } else {
                codigo = "";
            }

            return codigo;
        }

        public string formatoCuenta(string cuenta) {
            string espacio = cuenta.Replace(" ", "");
            return espacio.Insert(4, "-").Insert(9, "-").Insert(14, "-").Insert(19, "-").Trim();
        }

        public List<ProveedorEntity> listar() {
            string m = "";
            List<ProveedorEntity> lista = new List<ProveedorEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarProveedor", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    ProveedorEntity reg = new ProveedorEntity();
                    reg.codigo = dr[0].ToString();
                    reg.ruc = dr[1].ToString();
                    reg.razSocial = dr[2].ToString();
                    reg.repLegal = dr[3].ToString();
                    reg.direccion = dr[4].ToString();
                    reg.telefono = dr[5].ToString();
                    reg.correo = dr[6].ToString();
                    reg.fechaReg = Convert.ToDateTime(dr[7]);
                    reg.fechaAct = Convert.ToDateTime(dr[8]);
                    reg.ctaBancaria = dr[9].ToString();
                    reg.pais = dr[10].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }
        
        public string registrar(ProveedorEntity pro) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_RegistrarProveedor", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod", pro.codigo);
                cmd.Parameters.AddWithValue("@ruc", pro.ruc);
                cmd.Parameters.AddWithValue("@raz", pro.razSocial);
                cmd.Parameters.AddWithValue("@rep", pro.repLegal);
                cmd.Parameters.AddWithValue("@dir", pro.direccion);
                cmd.Parameters.AddWithValue("@tel", pro.telefono);
                cmd.Parameters.AddWithValue("@cor", pro.correo);
                cmd.Parameters.AddWithValue("@frg", pro.fechaReg);
                cmd.Parameters.AddWithValue("@fac", pro.fechaAct);
                cmd.Parameters.AddWithValue("@cta", pro.ctaBancaria);
                cmd.Parameters.AddWithValue("@pai", pro.pais);

                cmd.ExecuteNonQuery();

                m = "Registro Agregado";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return m;
        }

        public string actualizar(ProveedorEntity pro) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ActualizarProveedor", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ruc", pro.ruc);
                cmd.Parameters.AddWithValue("@raz", pro.razSocial);
                cmd.Parameters.AddWithValue("@rep", pro.repLegal);
                cmd.Parameters.AddWithValue("@dir", pro.direccion);
                cmd.Parameters.AddWithValue("@tel", pro.telefono);
                cmd.Parameters.AddWithValue("@cor", pro.correo);
                cmd.Parameters.AddWithValue("@fac", pro.fechaAct);
                cmd.Parameters.AddWithValue("@cta", pro.ctaBancaria);
                cmd.Parameters.AddWithValue("@pai", pro.pais);
                cmd.Parameters.AddWithValue("@cod", pro.codigo);

                cmd.ExecuteNonQuery();

                m = "Registro Actualizado";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return m;
        }
    }
}
