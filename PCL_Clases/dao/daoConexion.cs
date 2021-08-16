using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PCL_Clases.dao
{
    public class daoConexion
    {
        private string cadenaConexion;
        private SqlConnection cxn = null;

        public string CadenaConexion { get => cadenaConexion; }

        public daoConexion(string sCadenaConexion)
        {
            this.cadenaConexion = sCadenaConexion;
        }

        public SqlConnection AbrirConexion()
        {
            try
            {
                cxn = new SqlConnection(this.CadenaConexion);
                if (cxn.State == ConnectionState.Open) cxn.Close();
                cxn.Open();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de conexion con la base de datos. " + ex.Message);
            }
            catch (Exception gen)
            {
                throw new Exception("Error: " + gen.Message);
            }
            finally
            {
            }
            return cxn;
        }

        public void CerrarConexion()
        {
            if (cxn != null)
            {
                cxn.Close();
                cxn.Dispose();
            }
        }
    }
}
