using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PCL_Clases.str;

namespace PCL_Clases.dao
{
    public class daoProspecto
    {
        private string CadenaConexion = string.Empty;

        public daoProspecto(string sCadenaConexion)
        {
            this.CadenaConexion = sCadenaConexion;
        }

        public int Agregar(strProspecto str)
        {
            string query = "Insert into prospecto (Id,Nombre,ApellidoPaterno,ApellidoMaterno,Rfc,Estatus) " +
                "values (@Id,@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Rfc,@Estatus) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlConnection sql = dao.AbrirConexion();

            SqlCommand cmd = new SqlCommand(query, sql);

            AgregarParametros(cmd, str, 1);

            int save = cmd.ExecuteNonQuery();

            if (cmd != null)
                cmd.Dispose();

            dao.CerrarConexion();

            return save;
        }

        public int Modificar(strProspecto str)
        {
            string query = "Update prospecto set " +
                "Nombre=@Nombre,ApellidoPaterno=@ApellidoPaterno," +
                "ApellidoMaterno=@ApellidoMaterno,Rfc=@Rfc" +
                "where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlConnection sql = dao.AbrirConexion();

            SqlCommand cmd = new SqlCommand(query, sql);

            AgregarParametros(cmd, str, 0);

            int save = cmd.ExecuteNonQuery();

            if (cmd != null)
                cmd.Dispose();

            dao.CerrarConexion();

            return save;
        }

        public int ModificarEstatus(long id, string estatus, string observaciones = null)
        {
            string query = string.Empty;
            if (String.IsNullOrEmpty(observaciones) == false)
            {
                query = "Update prospecto set " +
                    "Estatus=@Estatus,Observaciones=@Observaciones " +
                    "where Id=@Id ";
            }
            else
            {
                query = "Update prospecto set " +
                    "Estatus=@Estatus " +
                    "where Id=@Id ";
            }

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlConnection sql = dao.AbrirConexion();

            SqlCommand cmd = new SqlCommand(query, sql);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Estatus", estatus);
            if (String.IsNullOrEmpty(observaciones) == false)
                cmd.Parameters.AddWithValue("@Observaciones", observaciones);

            int save = cmd.ExecuteNonQuery();

            if (cmd != null)
                cmd.Dispose();

            dao.CerrarConexion();

            return save;
        }

        public strProspecto ObtenerProspecto(long id)
        {
            string query = "Select * from prospecto where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlConnection sql = dao.AbrirConexion();

            SqlCommand cmd = new SqlCommand(query, sql);

            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataReader lector = cmd.ExecuteReader();

            strProspecto str = null;

            str = CargaObjeto(lector, str);

            return str;
        }

        public List<strProspecto> ObtenerListadoDeProspectos(string condicion = null)
        {
            string query = "Select * from prospecto " + condicion + " order by Nombre,ApellidoPaterno,ApellidoMaterno asc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlConnection sql = dao.AbrirConexion();

            SqlCommand cmd = new SqlCommand(query, sql);

            SqlDataReader lector = cmd.ExecuteReader();

            List<strProspecto> str = null;

            str = CargaLista(lector, str);

            return str;
        }

        public long ObtenerNuevoId()
        {
            string query = "Select Id from prospecto order by Id desc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlConnection sql = dao.AbrirConexion();

            SqlCommand cmd = new SqlCommand(query, sql);

            SqlDataReader lector = cmd.ExecuteReader();

            long id = 0;

            if (lector != null && lector.Read())
            {
                id = long.Parse(lector["Id"].ToString());

                id = id + 1;
            }
            else
                id = 1;

            return id;
        }

        private List<strProspecto> CargaLista(SqlDataReader lector, List<strProspecto> str)
        {
            while (lector != null && lector.Read())
            {
                if (str == null) str = new List<strProspecto>();
                str.Add(new strProspecto()
                {
                    Id = long.Parse(lector["Id"].ToString()),
                    Nombre = lector["Nombre"].ToString(),
                    ApellidoPaterno = lector["ApellidoPaterno"].ToString(),
                    ApellidoMaterno = lector["ApellidoMaterno"].ToString(),
                    Rfc = lector["Rfc"].ToString(),
                    Status = lector["Estatus"].ToString(),
                    Observaciones = lector["Observaciones"].ToString()
                });
            }
            return str;
        }

        private strProspecto CargaObjeto(SqlDataReader lector, strProspecto str)
        {
            if (lector != null && lector.Read())
            {
                if (str == null) str = new strProspecto();
                str.Id = long.Parse(lector["Id"].ToString());
                str.Nombre = lector["Nombre"].ToString();
                str.ApellidoPaterno = lector["ApellidoPaterno"].ToString();
                str.ApellidoMaterno = lector["ApellidoMaterno"].ToString();
                str.Rfc = lector["Rfc"].ToString();
                str.Status = lector["Estatus"].ToString();
                str.Observaciones = lector["Observaciones"].ToString();
            }
            return str;
        }

        private void AgregarParametros(SqlCommand cmd, strProspecto str, int agregar)
        {
            cmd.Parameters.AddWithValue("@Id", str.Id);
            cmd.Parameters.AddWithValue("@Nombre", str.Nombre);
            cmd.Parameters.AddWithValue("@ApellidoPaterno", str.ApellidoPaterno);
            cmd.Parameters.AddWithValue("@ApellidoMaterno", str.ApellidoMaterno);
            cmd.Parameters.AddWithValue("@Rfc", str.Rfc);
            if (agregar == 1)
                cmd.Parameters.AddWithValue("@Estatus", str.Status);
        }
    }
}
