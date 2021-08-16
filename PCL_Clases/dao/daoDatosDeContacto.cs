using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PCL_Clases.str;

namespace PCL_Clases.dao
{
    public class daoDatosDeContacto
    {
        private string CadenaConexion = string.Empty;

        public daoDatosDeContacto(string sCadenaConexion)
        {
            this.CadenaConexion = sCadenaConexion;
        }

        public int Agregar(strDatosDeContacto str)
        {
            string query = "Insert into datosDeContacto (Prospecto,Calle,Numero,Colonia,CodigoPostal,Telefono) " +
                "values (@Prospecto,@Calle,@Numero,@Colonia,@CodigoPostal,@Telefono) ";

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

        public int Modificar(strDatosDeContacto str)
        {
            string query = "Update datosDeContacto set Calle=@Calle,Numero=@Numero,Colonia=@Colonia," +
                "CodigoPostal=@CodigoPostal,Telefono=@Telefono " +
                "where Prospecto=@Prospecto ";

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

        public strDatosDeContacto ObtenerProspecto(long Prospectoid)
        {
            string query = "Select * from datosDeContacto where Prospecto=@Prospecto ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlConnection sql = dao.AbrirConexion();

            SqlCommand cmd = new SqlCommand(query, sql);

            cmd.Parameters.AddWithValue("@Prospecto", Prospectoid);

            SqlDataReader lector = cmd.ExecuteReader();

            strDatosDeContacto str = null;

            str = CargaObjeto(lector, str);

            return str;
        }

        public List<strDatosDeContacto> ObtenerListadoDeProspectos()
        {
            string query = "Select * from datosDeContacto ";

            daoConexion dao = new daoConexion(this.CadenaConexion);

            SqlConnection sql = dao.AbrirConexion();

            SqlCommand cmd = new SqlCommand(query, sql);

            SqlDataReader lector = cmd.ExecuteReader();

            List<strDatosDeContacto> str = null;

            str = CargaLista(lector, str);

            return str;
        }

        private List<strDatosDeContacto> CargaLista(SqlDataReader lector, List<strDatosDeContacto> str)
        {
            while (lector != null && lector.Read())
            {
                if (str == null) str = new List<strDatosDeContacto>();
                str.Add(new strDatosDeContacto()
                {
                    Prospecto = long.Parse(lector["Prospecto"].ToString()),
                    Calle = lector["Calle"].ToString(),
                    Numero = lector["Numero"].ToString(),
                    Colonia = lector["Colonia"].ToString(),
                    CodigoPostal = lector["CodigoPostal"].ToString(),
                    Telefono = lector["Telefono"].ToString()
                });
            }
            return str;
        }

        private strDatosDeContacto CargaObjeto(SqlDataReader lector, strDatosDeContacto str)
        {
            if (lector != null && lector.Read())
            {
                if (str == null) str = new strDatosDeContacto();
                str.Prospecto = long.Parse(lector["Prospecto"].ToString());
                str.Calle = lector["Calle"].ToString();
                str.Numero = lector["Numero"].ToString();
                str.Colonia = lector["Colonia"].ToString();
                str.CodigoPostal = lector["CodigoPostal"].ToString();
                str.Telefono = lector["Telefono"].ToString();
            }
            return str;
        }

        private void AgregarParametros(SqlCommand cmd, strDatosDeContacto str)
        {
            cmd.Parameters.AddWithValue("@Prospecto", str.Prospecto);
            cmd.Parameters.AddWithValue("@Calle", str.Calle);
            cmd.Parameters.AddWithValue("@Numero", str.Numero);
            cmd.Parameters.AddWithValue("@Colonia", str.Colonia);
            cmd.Parameters.AddWithValue("@CodigoPostal", str.CodigoPostal);
            cmd.Parameters.AddWithValue("@Telefono", str.Telefono);
        }
    }
}
