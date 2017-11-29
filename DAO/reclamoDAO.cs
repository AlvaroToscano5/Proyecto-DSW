using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//libreria
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
 public class reclamoDAO
    {
        conexionDAO cn = new conexionDAO();

        public string generar(ReclamoEntity pro)
        {
            string m = "";
            cn.getcn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_GenerarReclamo", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CODIGO", pro.codigo);
                cmd.Parameters.AddWithValue("@DNIUSUARIO", pro.dniUsuario);
                cmd.Parameters.AddWithValue("@NOMBREUSUARIO", pro.nombreUsuario);
                cmd.Parameters.AddWithValue("@APELLIDOUSUARIO", pro.apellidoUsuario);
                cmd.Parameters.AddWithValue("@TIPOUSUARIO", pro.tipoUsuario);
                cmd.Parameters.AddWithValue("@FECHAREG", pro.fechaReg);
                cmd.Parameters.AddWithValue("@ESTADO", pro.fechaReg);
                cmd.Parameters.AddWithValue("@DESCRIPCION", pro.descripcion);
                cmd.Parameters.AddWithValue("@USUARIOCODIGO", pro.usuario);
                cmd.Parameters.AddWithValue("@ESTACIONCODGIO", pro.estacion);
                cmd.Parameters.AddWithValue("@EMPLEADOCODIGO", pro.empleado);

                cmd.ExecuteNonQuery();

                m = "Reclamo Enviado con éxito";
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return m;


        }

        public List<ReclamoEntity> listarReclamo()
        {
            string m = "";
            List<ReclamoEntity> lista = new List<ReclamoEntity>();
            cn.getcn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_ListarReclamo", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ReclamoEntity reg = new ReclamoEntity();
                    reg.codigo = dr["codigo"].ToString();
                    reg.dniUsuario = dr["descripcion"].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }
    }
}
