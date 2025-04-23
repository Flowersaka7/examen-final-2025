using System;
using System.Web.UI.WebControls;
using ProyectoPlantas.CapaLogica;
using ProyectoPlantas.CapaDatos;

namespace WebApplication2.CapaDeVista
{
    public partial class FrmPlantas : System.Web.UI.Page
    {
        PlantaBLL plantaBLL = new PlantaBLL();
        CategoriaBLL categoriaBLL = new CategoriaBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
                CargarPlantas();
                CargarFiltroCategorias();
            }
        }

        private void CargarCategorias()
        {
            ddlCategoria.DataSource = categoriaBLL.ObtenerCategorias();
            ddlCategoria.DataTextField = "NombreCategoria";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();
        }

        private void CargarFiltroCategorias()
        {
            ddlFiltroCategoria.DataSource = categoriaBLL.ObtenerCategorias();
            ddlFiltroCategoria.DataTextField = "NombreCategoria";
            ddlFiltroCategoria.DataValueField = "Id";
            ddlFiltroCategoria.DataBind();

            ddlFiltroCategoria.Items.Insert(0, new ListItem("Todas las categorías", "0"));
        }

        private void CargarPlantas()
        {
            gvPlantas.DataSource = plantaBLL.ObtenerPlantas();
            gvPlantas.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Cls_Planta planta = new Cls_Planta
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                CategoriaId = int.Parse(ddlCategoria.SelectedValue)
            };

            plantaBLL.InsertarPlanta(planta);
            CargarPlantas();
            LimpiarFormulario();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Cls_Planta planta = new Cls_Planta
            {
                Id = int.Parse(txtID.Text),
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                CategoriaId = int.Parse(ddlCategoria.SelectedValue)
            };

            plantaBLL.ActualizarPlanta(planta);
            CargarPlantas();
            LimpiarFormulario();

            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
        }

        protected void gvPlantas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow fila = gvPlantas.Rows[index];

            int id = int.Parse(fila.Cells[0].Text);

            if (e.CommandName == "Seleccionar")
            {
                txtID.Text = fila.Cells[0].Text;
                txtNombre.Text = fila.Cells[1].Text;
                txtDescripcion.Text = fila.Cells[2].Text;

              
                ListItem item = ddlCategoria.Items.FindByText(fila.Cells[3].Text);
                if (item != null)
                {
                    ddlCategoria.SelectedValue = item.Value;
                }

                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
            }
            else if (e.CommandName == "Eliminar")
            {
                plantaBLL.EliminarPlanta(id);
                CargarPlantas();
            }
        }

        protected void ddlFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCategoria = int.Parse(ddlFiltroCategoria.SelectedValue);

            if (idCategoria == 0)
            {
                CargarPlantas();
            }
            else
            {
                gvPlantas.DataSource = plantaBLL.ObtenerPlantasPorCategoria(idCategoria);
                gvPlantas.DataBind();
            }
        }

        private void LimpiarFormulario()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            ddlCategoria.SelectedIndex = 0;
            ddlFiltroCategoria.SelectedIndex = 0;
        }
    }
}
