using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PCL_Clases.str;
using PCL_Clases.dao;
using UI.Code;

namespace UI
{
    public partial class EvaluacionDelProspecto : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Remove("Id");
                CargarGrid();
            }
        }

        private void CargarGrid()
        {
            daoProspecto dao = new daoProspecto(this.CadenaConexionSql);
            List<strProspecto> lista = dao.ObtenerListadoDeProspectos("where Estatus='" + this.Estatus[0].value.ToString() + "'");
            gvProspectos.DataSource = lista;
            gvProspectos.DataBind();
        }

        protected void gvProspectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlGrid.Visible = false;
            template.Visible = true;
            Session["Id"] = gvProspectos.SelectedRow.Cells[0].Text;
        }

        protected void rbA_CheckedChanged(object sender, EventArgs e)
        {
            if (rbA.Checked)
            {
                txtObservaciones.Text = "";
                pnlObserv.Visible = false;
            }
        }

        protected void rbR_CheckedChanged(object sender, EventArgs e)
        {
            if (rbR.Checked)
            {
                pnlObserv.Visible = true;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            daoProspecto dao = new daoProspecto(this.CadenaConexionSql);
            string mensaje = string.Empty;
            long id = long.Parse(Session["Id"].ToString());
            ObtenerEstatus(out mensaje);
            if (mensaje == "R")
            {
                if (txtObservaciones.Text != "")
                    dao.ModificarEstatus(id, ObtenerEstatus(out mensaje), txtObservaciones.Text.ToUpper());
                else
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('Favor de indicar las observaciones del rechazo.');", true);
            }
            else
                dao.ModificarEstatus(id, ObtenerEstatus(out mensaje));
            CerrarTemplate();
        }

        private string ObtenerEstatus(out string mensaje)
        {
            mensaje = string.Empty;
            if (rbA.Checked)
                return this.Estatus[1].value.ToString();
            else
            {
                mensaje = "R";
                return this.Estatus[2].value.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            CerrarTemplate();
        }

        private void CerrarTemplate()
        {
            Session.Remove("Id");
            CargarGrid();
            txtObservaciones.Text = "";
            template.Visible = false;
            pnlGrid.Visible = true;
        }
    }
}
