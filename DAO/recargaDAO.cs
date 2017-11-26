using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class recargaDAO {
        conexionDAO cn = new conexionDAO();

        public string generarCodigo() {
            DataTable dt = new DataTable();
            string m = "";
            string codigo = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarRecarga", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }

            if (dt.Rows.Count < 9) {
                codigo = "R00000000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 99) {
                codigo = "R0000000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 999) {
                codigo = "R000000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 9999) {
                codigo = "R00000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 99999) {
                codigo = "R0000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 999999) {
                codigo = "R000" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 9999999) {
                codigo = "R00" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 99999999) {
                codigo = "R0" + (dt.Rows.Count + 1).ToString();
            } else if (dt.Rows.Count < 999999999) {
                codigo = "R" + (dt.Rows.Count + 1).ToString();
            } else {
                codigo = "";
            }

            return codigo;
        }
        
        public string actualizarSaldo(double monto, string dni) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ActualizarSaldo", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sal", monto);
                cmd.Parameters.AddWithValue("@dni", dni);

                cmd.ExecuteNonQuery();

                m = "Recarga Realizada con Éxito";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return m;
        }

        public string recargar(RecargaEntity rec) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_RecargarSaldo", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod", rec.codigo);
                cmd.Parameters.AddWithValue("@mon", rec.monto);
                cmd.Parameters.AddWithValue("@frg", rec.fechaReg);
                cmd.Parameters.AddWithValue("@dni", rec.dni);
                cmd.Parameters.AddWithValue("@usu", rec.usuario);

                cmd.ExecuteNonQuery();

                m = "Registro Agregado";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }

            if (m == "Registro Agregado") {
                m = actualizarSaldo(rec.monto, rec.dni);
            }

            return m;
        }
    }
}
