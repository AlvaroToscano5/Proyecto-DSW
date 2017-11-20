using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class mobiliarioDAO {
        conexionDAO cn = new conexionDAO();

        public string generarCodigo() {
            DataTable dt = new DataTable();
            string m = "";
            string codigo = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarMobiliario", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }

            if (dt.Rows.Count < 9) {
                codigo = "M00000000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 99) {
                codigo = "M0000000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 999) {
                codigo = "M000000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 9999) {
                codigo = "M00000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 99999) {
                codigo = "M0000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 999999) {
                codigo = "M000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 9999999) {
                codigo = "M00" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 99999999) {
                codigo = "M0" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 999999999) {
                codigo = "M" + (dt.Rows.Count + 1).ToString();
            } else {
                codigo = "";
            }

            return codigo;
        }

        public List<MobiliarioEntity> listar() {
            string m = "";
            List<MobiliarioEntity> lista = new List<MobiliarioEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarMobiliario", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    MobiliarioEntity reg = new MobiliarioEntity();
                    reg.codigo = dr[0].ToString();
                    reg.descripcion = dr[1].ToString();
                    reg.cantidad = Convert.ToInt32(dr[2]);
                    reg.fechaReg = dr[3].ToString();
                    reg.fechaAct = dr[4].ToString();
                    reg.proveedor = dr[5].ToString();
                    reg.tipo = dr[6].ToString();
                    reg.estado = dr[7].ToString();
                    reg.estacion = dr[8].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }

        public string registrar(MobiliarioEntity mob) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_RegistrarMobiliario", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod", mob.codigo);
                cmd.Parameters.AddWithValue("@des", mob.descripcion);
                cmd.Parameters.AddWithValue("@can", mob.cantidad);
                cmd.Parameters.AddWithValue("@frg", mob.fechaReg);
                cmd.Parameters.AddWithValue("@fac", mob.fechaAct);
                cmd.Parameters.AddWithValue("@pro", mob.proveedor);
                cmd.Parameters.AddWithValue("@tip", mob.tipo);
                cmd.Parameters.AddWithValue("@eem", mob.estado);
                cmd.Parameters.AddWithValue("@est", mob.estacion);

                cmd.ExecuteNonQuery();

                m = "Registro Agregado";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return m;
        }

        public string actualizar(MobiliarioEntity mob) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ActualizarMobiliario", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@des", mob.descripcion);
                cmd.Parameters.AddWithValue("@can", mob.cantidad);
                cmd.Parameters.AddWithValue("@fac", mob.fechaAct);
                cmd.Parameters.AddWithValue("@pro", mob.proveedor);
                cmd.Parameters.AddWithValue("@tip", mob.tipo);
                cmd.Parameters.AddWithValue("@eem", mob.estado);
                cmd.Parameters.AddWithValue("@est", mob.estacion);
                cmd.Parameters.AddWithValue("@cod", mob.codigo);

                cmd.ExecuteNonQuery();

                m = "Registro Actualizado";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return m;
        }
    }
}
