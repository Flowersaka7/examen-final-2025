using System.Data;
using ProyectoPlantas.CapaDatos;

namespace ProyectoPlantas.CapaLogica
{
    public class CategoriaBLL
    {
        private CategoriaDAL categoriaDAL = new CategoriaDAL();

        public DataTable ObtenerCategorias()
        {
            return categoriaDAL.Listar();
        }

        public void InsertarCategoria(Cls_Categoria categoria)
        {
            categoriaDAL.Insertar(categoria);
        }

        public void ActualizarCategoria(Cls_Categoria categoria)
        {
            categoriaDAL.Actualizar(categoria);
        }

        public void EliminarCategoria(int id)
        {
            categoriaDAL.Eliminar(id);
        }
    }
}
