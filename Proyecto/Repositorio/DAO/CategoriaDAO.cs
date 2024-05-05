using Microsoft.Data.SqlClient;
using System.Data;
using Proyecto.Models;
using Proyecto.Repositorio.Interfaces;

namespace Proyecto.Repositorio.DAO
{
    public class CategoriaDAO : ICategoria
    {

        private readonly string cadena;

        public CategoriaDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public string registrarCategoria(Categoria categoria)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombreCategoria", categoria.NombreCategoria);
                cmd.Parameters.AddWithValue("@estado", categoria.Estado);
                resultado = cmd.ExecuteNonQuery();
                mensaje = "La categoria " + categoria.NombreCategoria + "ha sido registrado correctamente";
            } 
            catch (Exception ex)
            {
                mensaje = "Error al registrar la categoria: " + ex.Message;
            }
            finally
            {
                cn.Close();
            }

            return mensaje;
        }

        public IEnumerable<Categoria> obtenerCategorias()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("sp_ListarCategorias", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Categoria categoria = new Categoria();
                categoria.CategoriaId = dr.GetInt32(0);
                categoria.NombreCategoria = dr.GetString(1);
                categoria.Estado = dr.GetString(2);

                listaCategorias.Add(categoria);
            }

            dr.Close();
            cn.Close();

            return listaCategorias;
        }

        public Categoria obtenerCategoriaPorId(string categoriaId)
        {
            throw new NotImplementedException();
        }

        public string actualizarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public string eliminarCategoria(string categoriaId)
        {
            throw new NotImplementedException();
        }
    }
}
