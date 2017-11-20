using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class estacionDAO {
        conexionDAO cn = new conexionDAO();

        public List<EstacionEntity> listarEstacion() {
            string m = "";
            List<EstacionEntity> lista = new List<EstacionEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarEstacion", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    EstacionEntity reg = new EstacionEntity();
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
