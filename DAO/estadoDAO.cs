using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class estadoDAO {
        conexionDAO cn = new conexionDAO();

        public List<EstadoEntity> listarEstadoEmpUsu() {
            string m = "";
            List<EstadoEntity> lista = new List<EstadoEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarEstadoEmpUsu", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    EstadoEntity reg = new EstadoEntity();
                    reg.codigo = dr["codigo"].ToString();
                    reg.descripcion = dr["descripcion"].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }

        public List<EstadoEntity> listarEstadoMobEquip() {
            string m = "";
            List<EstadoEntity> lista = new List<EstadoEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarEstadoMobEquip", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    EstadoEntity reg = new EstadoEntity();
                    reg.codigo = dr["codigo"].ToString();
                    reg.descripcion = dr["descripcion"].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }
    }
}
