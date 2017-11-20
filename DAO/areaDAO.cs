using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class areaDAO {
        conexionDAO cn = new conexionDAO();

        public List<AreaEntity> listarArea() {
            string m = "";
            List<AreaEntity> lista = new List<AreaEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarArea", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    AreaEntity reg = new AreaEntity();
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
