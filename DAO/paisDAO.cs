using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class paisDAO {
        conexionDAO cn = new conexionDAO();

        public List<PaisEntity> listarPais() {
            string m = "";
            List<PaisEntity> lista = new List<PaisEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarPais", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    PaisEntity reg = new PaisEntity();
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
