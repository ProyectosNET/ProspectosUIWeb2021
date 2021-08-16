using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI;

namespace UI.Code
{
    public class BasePage : Page
    {
        public string CadenaConexionSql
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            }
        }

        public string RutaDeDocumentos
        {
            get
            {
                return ConfigurationManager.AppSettings["docs"].ToString();
            }
        }

        public List<Elementos> Estatus
        {
            get
            {
                return CargarEstatus();
            }
        }

        private List<Elementos> CargarEstatus()
        {
            List<Elementos> elem1 = new List<Elementos>();
            elem1.Add(new Elementos() { value = "Enviado", text = "Enviado" });
            elem1.Add(new Elementos() { value = "Autorizado", text = "Autorizado" });
            elem1.Add(new Elementos() { value = "Rechazado", text = "Rechazado" });
            return elem1;
        }
    }

    public class Elementos
    {
        public object value { get; set; }
        public string text { get; set; }
    }
}
