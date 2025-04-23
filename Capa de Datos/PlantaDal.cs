using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoPlantas.CapaDatos
{
    public class PlantaDAL
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        public DataTable Listar()
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_ListarPlantas", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void Insertar(Cls_Planta planta)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertarPlanta", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", planta.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", planta.Descripcion);
            cmd.Parameters.AddWithValue("@CategoriaId", planta.CategoriaId);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void Actualizar(Cls_Planta planta)
        {
            SqlCommand cmd = new SqlCommand("sp_ActualizarPlanta", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", planta.Id);
            cmd.Parameters.AddWithValue("@Nombre", planta.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", planta.Descripcion);
            cmd.Parameters.AddWithValue("@CategoriaId", planta.CategoriaId);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public DataTable ObtenerPorCategoria(int categoriaId)
        {
            SqlCommand cmd = new SqlCommand("SELECT p.Id, p.Nombre, p.Descripcion, c.NombreCategoria AS Categoria, p.FechaRegistro FROM Plantas p INNER JOIN Categorias c ON p.CategoriaId = c.Id WHERE p.Estado = 1 AND p.CategoriaId = @CategoriaId", cn);
            cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void Eliminar(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_EliminarPlanta", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
