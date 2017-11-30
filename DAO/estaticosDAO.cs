using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class estaticosDAO {
        conexionDAO cn = new conexionDAO();

        public List<EstaticosEntity> estadosReclamos() {
            List<EstaticosEntity> lista = new List<EstaticosEntity>();
            EstaticosEntity estados1 = new EstaticosEntity();
            estados1.codigo = "Por Revisar";
            estados1.descripcion = "Por Revisar";
            lista.Add(estados1);
            EstaticosEntity estados2 = new EstaticosEntity();
            estados2.codigo = "Aprobado";
            estados2.descripcion = "Aprobado";
            lista.Add(estados2);
            EstaticosEntity estados3 = new EstaticosEntity();
            estados3.codigo = "Denegado";
            estados3.descripcion = "Denegado";
            lista.Add(estados3);

            return lista;
        }

        public List<EstaticosEntity> generos() {
            List<EstaticosEntity> lista = new List<EstaticosEntity>();
            EstaticosEntity generos1 = new EstaticosEntity();
            generos1.codigo = "Femenino";
            generos1.descripcion = "Femenino";
            lista.Add(generos1);
            EstaticosEntity generos2 = new EstaticosEntity();
            generos2.codigo = "Masculino";
            generos2.descripcion = "Masculino";
            lista.Add(generos2);

            return lista;
        }

        public List<EstaticosEntity> empleados() {
            string m = "";
            List<EstaticosEntity> lista = new List<EstaticosEntity>();
            cn.getcn.Open();

            try {
                SqlCommand cmd = new SqlCommand("usp_ListarEmpleadoOperaciones", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    EstaticosEntity reg = new EstaticosEntity();
                    reg.codigo = dr["codigo"].ToString();
                    reg.descripcion = dr["nomcompleto"].ToString();
                    lista.Add(reg);
                }
            }
            catch (SqlException ex) { m = ex.Message; }
            finally { cn.getcn.Close(); }
            return lista;
        }
    }
}
