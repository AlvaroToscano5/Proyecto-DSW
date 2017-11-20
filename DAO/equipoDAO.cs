using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class equipoDAO {
        conexionDAO cn = new conexionDAO();

        public string generarCodigo() {
            DataTable dt = new DataTable();
            string m = "";
            string codigo = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarEquipo", cn.getcn);
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

        public List<EquipoEntity> listar() {
            string m = "";
            List<EquipoEntity> lista = new List<EquipoEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarEquipo", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    EquipoEntity reg = new EquipoEntity();
                    reg.codigo = dr[0].ToString();
                    reg.descripcion = dr[1].ToString();
                    reg.placa = dr[2].ToString();
                    reg.fechaReg = dr[3].ToString();
                    reg.fechaAct = dr[4].ToString();
                    reg.proveedor = dr[5].ToString();
                    reg.tipo = dr[6].ToString();
                    reg.estado = dr[7].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }

        public string registrar(EquipoEntity equ) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_RegistrarEquipo", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod", equ.codigo);
                cmd.Parameters.AddWithValue("@des", equ.descripcion);
                cmd.Parameters.AddWithValue("@pla", equ.placa);
                cmd.Parameters.AddWithValue("@frg", equ.fechaReg);
                cmd.Parameters.AddWithValue("@fac", equ.fechaAct);
                cmd.Parameters.AddWithValue("@pro", equ.proveedor);
                cmd.Parameters.AddWithValue("@tip", equ.tipo);
                cmd.Parameters.AddWithValue("@eem", equ.estado);

                cmd.ExecuteNonQuery();

                m = "Registro Agregado";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return m;
        }

        public string actualizar(EquipoEntity equ) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ActualizarEquipo", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@des", equ.descripcion);
                cmd.Parameters.AddWithValue("@pla", equ.placa);
                cmd.Parameters.AddWithValue("@fac", equ.fechaAct);
                cmd.Parameters.AddWithValue("@pro", equ.proveedor);
                cmd.Parameters.AddWithValue("@tip", equ.tipo);
                cmd.Parameters.AddWithValue("@eem", equ.estado);
                cmd.Parameters.AddWithValue("@cod", equ.codigo);

                cmd.ExecuteNonQuery();

                m = "Registro Actualizado";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return m;
        }
    }
}
