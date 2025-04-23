using System.Data;
using ProyectoPlantas.CapaDatos;

namespace ProyectoPlantas.CapaLogica
{
    public class PlantaBLL
    {
        private PlantaDAL plantaDAL = new PlantaDAL();

        public DataTable ObtenerPlantas()
        {
            return plantaDAL.Listar();
        }

        public void InsertarPlanta(Cls_Planta planta)
        {
            plantaDAL.Insertar(planta);
        }

        public DataTable ObtenerPlantasPorCategoria(int categoriaId)
        {
            return plantaDAL.ObtenerPorCategoria(categoriaId);
        }

        public void ActualizarPlanta(Cls_Planta planta)
        {
            plantaDAL.Actualizar(planta);
        }

        public void EliminarPlanta(int id)
        {
            plantaDAL.Eliminar(id);
        }
    }
}
