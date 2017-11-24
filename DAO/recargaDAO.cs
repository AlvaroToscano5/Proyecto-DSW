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
                SqlCommand cmd = new SqlCommand("usp_Recargar", cn.getcn);
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
