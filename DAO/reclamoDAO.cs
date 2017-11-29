using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
 public class reclamoDAO {
        conexionDAO cn = new conexionDAO();

        public string generar(ReclamoEntity pro) {
            string m = "";
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_GenerarReclamo", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod", pro.codigo);
                cmd.Parameters.AddWithValue("@dni", pro.dni);
                cmd.Parameters.AddWithValue("@nom", pro.nombre);
                cmd.Parameters.AddWithValue("@ape", pro.apellido);
                cmd.Parameters.AddWithValue("@tip", pro.tipo);
                cmd.Parameters.AddWithValue("@frg", pro.fechaReg);
                cmd.Parameters.AddWithValue("@fac", pro.fechaAct);
                cmd.Parameters.AddWithValue("@etr", pro.fechaReg);
                cmd.Parameters.AddWithValue("@des", pro.descripcion);
                cmd.Parameters.AddWithValue("@usu", pro.usuario);
                cmd.Parameters.AddWithValue("@est", pro.estacion);
                cmd.Parameters.AddWithValue("@emp", pro.empleado);

                cmd.ExecuteNonQuery();

                m = "Reclamo Enviado con éxito";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }

            return m;
        }

        public List<ReclamoEntity> listarReclamo() {
            string m = "";
            List<ReclamoEntity> lista = new List<ReclamoEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarReclamo", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    ReclamoEntity reg = new ReclamoEntity();
                    reg.codigo = dr[0].ToString();
                    reg.dni = dr[1].ToString();
                    reg.nombre = dr[2].ToString();
                    reg.apellido = dr[3].ToString();
                    reg.tipo = dr[4].ToString();
                    reg.fechaReg = Convert.ToDateTime(dr[5]);
                    reg.fechaAct = Convert.ToDateTime(dr[6]);
                    reg.estado = dr[7].ToString();
                    reg.descripcion = dr[8].ToString();
                    reg.usuario = dr[9].ToString();
                    reg.estacion = dr[10].ToString();
                    reg.empleado = dr[11].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }
    }
}
