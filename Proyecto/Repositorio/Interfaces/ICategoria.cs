using Proyecto.Models;

namespace Proyecto.Repositorio.Interfaces
{
    public interface ICategoria
    {
        string registrarCategoria(Categoria categoria);

        IEnumerable<Categoria> obtenerCategorias();

        Categoria obtenerCategoriaPorId(string categoriaId);

        string actualizarCategoria(Categoria categoria);

        String eliminarCategoria(string categoriaId);
    }
}
