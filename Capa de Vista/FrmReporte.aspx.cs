using System;
using ProyectoPlantas.CapaLogica;

namespace ProyectoPlantas.CapaPresentacion
{
    public partial class FrmReporte : System.Web.UI.Page
    {
        ReporteBLL reporteBLL = new ReporteBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvReporte.DataSource = reporteBLL.ObtenerReporte();
                gvReporte.DataBind();
            }
        }
    }
}
