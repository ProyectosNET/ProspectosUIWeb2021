using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.Code;
using PCL_Clases.str;
using PCL_Clases.dao;

namespace UI
{
    public partial class ListadoDeProspectos : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                daoProspecto dao = new daoProspecto(this.CadenaConexionSql);
                List<strProspecto> prospectos = dao.ObtenerListadoDeProspectos();
                if (prospectos != null)
                {
                    gvProspectos.DataSource = prospectos;
                    gvProspectos.DataBind();
                }
            }
        }

        protected void gvProspectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            long id = long.Parse(gvProspectos.SelectedRow.Cells[0].Text);

            this.Page.Response.Redirect("/DetalleProspecto.aspx?id=" + id);
        }
    }
}
