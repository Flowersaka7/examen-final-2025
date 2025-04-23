using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 

namespace ProyectoPlantas.CapaDatos
{
    public class CategoriaDAL
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public DataTable Listar()
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_ListarCategorias", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

public void Insertar(Cls_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertarCategoria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NombreCategoria", categoria.NombreCategoria);
            cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void Actualizar(Cls_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("sp_ActualizarCategoria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", categoria.Id);
            cmd.Parameters.AddWithValue("@NombreCategoria", categoria.NombreCategoria);
            cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void Eliminar(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_EliminarCategoria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}

