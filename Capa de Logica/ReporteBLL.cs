using System.Data;
using ProyectoPlantas.CapaDatos;

namespace ProyectoPlantas.CapaLogica
{
    public class ReporteBLL
    {
        private ReporteDAL reporteDAL = new ReporteDAL();

        public DataTable ObtenerReporte()
        {
            return reporteDAL.ObtenerReportePlantasPorCategoria();
        }
    }
}
