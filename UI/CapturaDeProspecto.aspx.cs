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
    public partial class CapturaDeProspecto : BasePage
    {
        public List<ListaDeDocumentos> pListaDeDocumentos
        {
            get
            {
                return (Session["sDocs"] != null) ? (List<ListaDeDocumentos>)Session["sDocs"] : null;
            }
            set
            {
                Session["sDocs"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Session.Remove("sDocs");
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (ValidarForm())
            {
                strProspecto str = new strProspecto();
                str = CargaDatos(str);

                strDatosDeContacto contacto = new strDatosDeContacto();
                contacto = CargaDatos(contacto, str.Id);

                daoProspecto prospecto = new daoProspecto(this.CadenaConexionSql);
                prospecto.Agregar(str);

                daoDatosDeContacto datosDeContacto = new daoDatosDeContacto(this.CadenaConexionSql);
                datosDeContacto.Agregar(contacto);

                daoDocumento documento = new daoDocumento(this.CadenaConexionSql);
                foreach (var item in this.pListaDeDocumentos)
                {
                    strDocumento documento1 = new strDocumento();
                    documento1.Id = documento.ObtenerNuevoId();
                    documento1.Nombre = txtNombreDoc.Text.ToUpper();
                    documento1.Archivo = item.guid + "," + item.value;
                    documento1.Mime = item.type;
                    documento1.Prospecto = str.Id;
                    documento.Agregar(documento1);
                }

                Session.Remove("sDocs");
                this.Page.Response.Redirect("ListadoDeProspectos.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CamposVacios", "alert('Hay Campos Vacíos.');", true);
            }
        }

        private strDatosDeContacto CargaDatos(strDatosDeContacto contacto, long id)
        {
            contacto.Prospecto = id;
            contacto.Calle = txtCalle.Text.ToUpper();
            contacto.CodigoPostal = txtCodigoPostal.Text;
            contacto.Colonia = txtColonia.Text.ToUpper();
            contacto.Numero = txtNumero.Text;
            contacto.Telefono = txtTelefono.Text;
            return contacto;
        }

        private strProspecto CargaDatos(strProspecto str)
        {
            daoProspecto dao = new daoProspecto(this.CadenaConexionSql);
            str.Id = dao.ObtenerNuevoId();
            str.Nombre = txtProspecto.Text.ToUpper();
            str.ApellidoPaterno = txtApellido1.Text.ToUpper();
            str.ApellidoMaterno = txtApellido2.Text.ToUpper();
            str.Rfc = txtRfc.Text.ToUpper();
            str.Status = this.Estatus[0].value.ToString();
            return str;
        }

        private bool ValidarForm()
        {
            if (txtApellido1.Text != "" && txtCalle.Text != "" && txtCodigoPostal.Text != "" && 
                txtColonia.Text != "" && txtNumero.Text != "" && txtProspecto.Text != "" && 
                txtRfc.Text != "" && txtTelefono.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (upload.HasFiles)
            {
                var archivos = upload.PostedFiles;
                foreach (var item in archivos)
                {
                    string guid_ = Guid.NewGuid().ToString();
                    if (this.pListaDeDocumentos == null) this.pListaDeDocumentos = new List<ListaDeDocumentos>();
                    this.pListaDeDocumentos.Add(new ListaDeDocumentos()
                    {
                        guid = guid_,
                        value = item.FileName,
                        type = item.ContentType
                    });
                    upload.SaveAs(Server.MapPath(this.RutaDeDocumentos + guid_ + "," + item.FileName));
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CamposVacios", "alert('No hay archivos cargados.');", true);
            }
        }
    }

    public class ListaDeDocumentos
    {
        public string guid { get; set; }
        public string value { get; set; }
        public string type { get; set; }
    }
}
