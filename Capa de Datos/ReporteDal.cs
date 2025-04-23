using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProyectoPlantas.CapaDatos
{
    public class ReporteDAL
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public DataTable ObtenerReportePlantasPorCategoria()
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_ReportePlantasPorCategoria", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
