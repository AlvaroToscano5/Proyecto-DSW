using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class tarjetaDAO {
        conexionDAO cn = new conexionDAO();

        public List<TarjetasEntity> listarVisa() {
            string m = "";
            List<TarjetasEntity> lista = new List<TarjetasEntity>();
            cn.visa.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_Listar", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    TarjetasEntity reg = new TarjetasEntity();
                    reg.codigo = dr["codigo"].ToString();
                    reg.numero = dr["numero"].ToString();
                    reg.titular = dr["titular"].ToString();
                    reg.fecha = Convert.ToDateTime(dr["fecha"]);
                    reg.cvc = dr["cvc"].ToString();
                    reg.tipo = dr["tipdoc"].ToString();
                    reg.numeroDoc = dr["numdoc"].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }

        public List<TarjetasEntity> listarMaster() {
            string m = "";
            List<TarjetasEntity> lista = new List<TarjetasEntity>();
            cn.master.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_Listar", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    TarjetasEntity reg = new TarjetasEntity();
                    reg.codigo = dr["codigo"].ToString();
                    reg.numero = dr["numero"].ToString();
                    reg.titular = dr["titular"].ToString();
                    reg.fecha = Convert.ToDateTime(dr["fecha"]);
                    reg.cvc = dr["cvc"].ToString();
                    reg.tipo = dr["tipdoc"].ToString();
                    reg.numeroDoc = dr["numdoc"].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }

    }
}
