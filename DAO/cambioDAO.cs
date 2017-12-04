using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class cambioDAO {
        conexionDAO cn = new conexionDAO();

        public List<MobiliarioEntity> listarMobiliarioCambio() {
            string m = "";
            List<MobiliarioEntity> listaMobiliario = new List<MobiliarioEntity>();
            cn.getcn.Open();

            try{
                SqlCommand cmd = new SqlCommand("usp_ListarMobiliario", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    MobiliarioEntity reg = new MobiliarioEntity();
                    reg.codigo = dr["codigo"].ToString();
                    reg.descripcion = dr["descripcion"].ToString();
                    reg.cantidad = Convert.ToInt32(dr["cantidad"]);
                    reg.fechaReg = Convert.ToDateTime(dr["fechareg"]);
                    reg.fechaAct = Convert.ToDateTime(dr["fechaAct"]);
                    reg.proveedor = dr["proveedorcodigo"].ToString();
                    reg.estacion = dr["estacióncodigo"].ToString();
                    reg.tipo = dr["TIPOEQMOBCODIGO"].ToString();
                    reg.estado = dr["ESTADOMOBEQUIPCODIGO"].ToString();

                    listaMobiliario.Add(reg);
                }
            }
            catch (SqlException ex){
                m = ex.Message;
            }
            finally {
                cn.getcn.Close();
            }

            return listaMobiliario;
        } 
        
        /*
        public List<MobiliarioEntity> listarMobiliarioCambioPrincipal()
        {
            string m = "";
            List<MobiliarioEntity> listaMobiliarioP = new List<MobiliarioEntity>();
            cn.getcn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_ListarMobiliarioCambio", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MobiliarioEntity reg = new MobiliarioEntity();
                    reg.codigo = dr["M.CODIGO"].ToString();
                    reg.descripcion = dr["M.DESCRIPCION"].ToString();
                    reg.estacion = dr["E.DESCRIPCION"].ToString();
                    reg.tipo = dr["TM.DESCRIPCION"].ToString();
                    reg.estado = dr["ES.DESCRIPCION"].ToString();

                    listaMobiliarioP.Add(reg);
                }
            }
            catch (SqlException ex)
            {
                m = ex.Message;
            }
            finally
            {
                cn.getcn.Close();
            }

            return listaMobiliarioP;
        }*/
    }
}
