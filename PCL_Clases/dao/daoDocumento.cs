using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCL_Clases.str;
using System.Data.SqlClient;

namespace PCL_Clases.dao
{
    public class daoDocumento
    {
        private string CadenaConexion = string.Empty;

        public daoDocumento(string sCadenaConexion)
        {
            this.CadenaConexion = sCadenaConexion;
        }

        public int Agregar(strDocumento str)
        {
            string query = "Insert into documentos (Id,Nombre,Archivo,Prospecto,Mime) " +
                "values (@Id,@Nombre,@Archivo,@Prospecto,@Mime) ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlConnection sql = dao.AbrirConexion();

            SqlCommand cmd = new SqlCommand(query, sql);

            AgregarParametros(cmd, str);

            int save = cmd.ExecuteNonQuery();

            if (cmd != null)
                cmd.Dispose();

            dao.CerrarConexion();

            return save;
        }

        public int Modificar(strDocumento str)
        {
            string query = "Update documentos set Nombre,Archivo,Prospecto,Mime " +
                "where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlConnection sql = dao.AbrirConexion();

            SqlCommand cmd = new SqlCommand(query, sql);

            AgregarParametros(cmd, str);

            int save = cmd.ExecuteNonQuery();

            if (cmd != null)
                cmd.Dispose();

            dao.CerrarConexion();

            return save;
        }

        public strDocumento ObtenerDocumento(int id)
        {
            string query = "Select * from documentos where Id=@Id ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlConnection sql = dao.AbrirConexion();

            SqlCommand cmd = new SqlCommand(query, sql);

            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataReader lector = cmd.ExecuteReader();

            strDocumento str = null;

            str = CargaObjeto(lector, str);

            return str;
        }

        public List<strDocumento> ObtenerDocumentos(string condicion = null)
        {
            string query = "Select * from documentos " + condicion + " order by Nombre asc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlConnection sql = dao.AbrirConexion();

            SqlCommand cmd = new SqlCommand(query, sql);

            SqlDataReader lector = cmd.ExecuteReader();

            List<strDocumento> str = null;

            str = CargaLista(lector, str);

            return str;
        }

        public int ObtenerNuevoId()
        {
            string query = "Select Id from documentos order by Id desc ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlConnection sql = dao.AbrirConexion();

            SqlCommand cmd = new SqlCommand(query, sql);

            SqlDataReader lector = cmd.ExecuteReader();

            int id = 0;

            if (lector != null && lector.Read())
            {
                id = int.Parse(lector["Id"].ToString());

                id = id + 1;
            }
            else
                id = 1;

            return id;
        }

        private List<strDocumento> CargaLista(SqlDataReader lector, List<strDocumento> str)
        {
            while (lector != null && lector.Read())
            {
                if (str == null) str = new List<strDocumento>();
                str.Add(new strDocumento()
                {
                    Id = int.Parse(lector["Id"].ToString()),
                    Nombre = lector["Nombre"].ToString(),
                    Archivo = lector["Archivo"].ToString(),
                    Prospecto = long.Parse(lector["Prospecto"].ToString()),
                    Mime = lector["Mime"].ToString()
                });
            }
            return str;
        }

        private strDocumento CargaObjeto(SqlDataReader lector, strDocumento str)
        {
            if (lector != null && lector.Read())
            {
                if (str == null) str = new strDocumento();
                str.Id = int.Parse(lector["Id"].ToString());
                str.Nombre = lector["Nombre"].ToString();
                str.Archivo = lector["Archivo"].ToString();
                str.Prospecto = long.Parse(lector["Prospecto"].ToString());
                str.Mime = lector["Mime"].ToString();
            }
            return str;
        }

        private void AgregarParametros(SqlCommand cmd, strDocumento str)
        {
            cmd.Parameters.AddWithValue("@Id", str.Id);
            cmd.Parameters.AddWithValue("@Nombre", str.Nombre);
            cmd.Parameters.AddWithValue("@Archivo", str.Archivo);
            cmd.Parameters.AddWithValue("@Prospecto", str.Prospecto);
            cmd.Parameters.AddWithValue("@Mime", str.Mime);
        }
    }
}
