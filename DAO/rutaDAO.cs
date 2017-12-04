using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class RutaDAO {
        conexionDAO cn = new conexionDAO();

        public string generarCodigo() {
            DataTable dt = new DataTable();
            string m = "";
            string codigo = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarRuta", cn.getcn);
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
            }  else if (dt.Rows.Count < 999999999) {
                codigo = "R" + (dt.Rows.Count + 1).ToString();
            } else {
                codigo = ""; }

            return codigo;
        }

        public string registrar(RutaEntity ru) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_RegistrarRuta", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod", ru.codigo);
                cmd.Parameters.AddWithValue("@fec", ru.fechaReg);
                cmd.Parameters.AddWithValue("@tur", ru.turno);
                cmd.Parameters.AddWithValue("@pla", ru.placa);
                cmd.Parameters.AddWithValue("@hor", ru.horaPartida);
                cmd.Parameters.AddWithValue("@tip", ru.tipo);
                cmd.Parameters.AddWithValue("@emp", ru.empleado);
                cmd.Parameters.AddWithValue("@eqp", ru.equipo);
     
                cmd.ExecuteNonQuery();

                m = "Registro Agregado";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return m;
        }

        public List<RutaEntity> listar() {
            string m = "";
            List<RutaEntity> lista = new List<RutaEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarRuta", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    RutaEntity reg = new RutaEntity();
                    reg.codigo = dr[0].ToString();
                    reg.fechaReg = Convert.ToDateTime(dr[1]);
                    reg.turno = dr[2].ToString();
                    reg.placa = dr[3].ToString();
                    reg.horaPartida = dr[4].ToString();
                    reg.tipo = dr[5].ToString();
                    reg.empleado = dr[6].ToString();
                    reg.equipo = dr[7].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }
    }
}
