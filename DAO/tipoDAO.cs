using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class tipoDAO {
        conexionDAO cn = new conexionDAO();

        public List<TipoEntity> listarTipoEmpleado() {
            string m = "";
            List<TipoEntity> lista = new List<TipoEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarTipoEmpleado", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    TipoEntity reg = new TipoEntity();
                    reg.codigo = dr["codigo"].ToString();
                    reg.descripcion = dr["descripcion"].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }

        public List<TipoEntity> listarTipoEqMob() {
            string m = "";
            List<TipoEntity> lista = new List<TipoEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarTipoEqMob", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    TipoEntity reg = new TipoEntity();
                    reg.codigo = dr["codigo"].ToString();
                    reg.descripcion = dr["descripcion"].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }

        public List<TipoEntity> listarTipoRuta() {
            string m = "";
            List<TipoEntity> lista = new List<TipoEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarTipoRuta", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    TipoEntity reg = new TipoEntity();
                    reg.codigo = dr["codigo"].ToString();
                    reg.descripcion = dr["descripcion"].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }

        public List<TipoEntity> listarTipoServicio() {
            string m = "";
            List<TipoEntity> lista = new List<TipoEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarTipoServicio", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    TipoEntity reg = new TipoEntity();
                    reg.codigo = dr["codigo"].ToString();
                    reg.descripcion = dr["descripcion"].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }

        public List<TipoEntity> listarTipoUsuario() {
            string m = "";
            List<TipoEntity> lista = new List<TipoEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarTipoUsuario", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    TipoEntity reg = new TipoEntity();
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
