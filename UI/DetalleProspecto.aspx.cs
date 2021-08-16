using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using PCL_Clases.str;
using PCL_Clases.dao;
using UI.Code;

namespace UI
{
    public partial class DetalleProspecto : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Remove("id_doc");

                if (this.Page.Request.QueryString["id"] != null)
                {
                    long id = long.Parse(this.Page.Request.QueryString["id"].ToString());
                    daoProspecto dao = new daoProspecto(this.CadenaConexionSql);
                    strProspecto prospecto = dao.ObtenerProspecto(id);
                    MostrarDatos(prospecto);
                }
            }
        }

        private void MostrarDatos(strProspecto str)
        {
            txtApellido1.Text = str.ApellidoPaterno;
            txtApellido2.Text = str.ApellidoMaterno;
            txtProspecto.Text = str.Nombre;
            txtRfc.Text = str.Rfc;

            daoDatosDeContacto dao = new daoDatosDeContacto(this.CadenaConexionSql);
            strDatosDeContacto str1 = dao.ObtenerProspecto(str.Id);
            txtCalle.Text = str1.Calle;
            txtCodigoPostal.Text = str1.CodigoPostal;
            txtColonia.Text = str1.Colonia;
            txtNumero.Text = str1.Numero;
            txtTelefono.Text = str1.Telefono;

            if (str.Status == this.Estatus[2].value.ToString())
            {
                pnlObserv.Visible = true;
                txtObservaciones.Text = str.Observaciones;
            }

            if (this.Page.Request.QueryString["id"] != null)
            {
                long idp = long.Parse(this.Page.Request.QueryString["id"].ToString());
                daoDocumento dao_ = new daoDocumento(this.CadenaConexionSql);
                List<strDocumento> lista = dao_.ObtenerDocumentos("where Prospecto=" + idp);
                if (lista != null)
                {
                    gvDocumentos.DataSource = lista;
                    gvDocumentos.DataBind();
                    pnlDescargar.Visible = true;
                }
            }
        }

        protected void gvDocumentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_doc = int.Parse(gvDocumentos.SelectedRow.Cells[0].Text);
            Session["id_doc"] = id_doc;
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            if (Session["id_doc"] != null)
            {
                int id_doc = int.Parse(Session["id_doc"].ToString());
                daoDocumento dao = new daoDocumento(this.CadenaConexionSql);
                strDocumento str = dao.ObtenerDocumento(id_doc);
                string path = Server.MapPath(this.RutaDeDocumentos + str.Archivo);
                Session.Remove("id_doc");

                string[] smime = str.Mime.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = smime[1];
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + str.Nombre);
                HttpContext.Current.Response.TransmitFile(path);
                HttpContext.Current.Response.End();
            }
            else
            {
                string clave = Guid.NewGuid().ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), clave, "alert('Favor de seleccionar un archivo para descargarlo.');", true);
            }
        }
    }
}
