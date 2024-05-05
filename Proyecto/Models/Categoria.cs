namespace Proyecto.Models
{
    public class Categoria
    {
        // Atributos
        private int categoriaId;
        private string nombreCategoria;
        private string estado;

        // Constructor por defecto
        public Categoria()
        {
            nombreCategoria = "";
            estado = "";
        }

        // Constructor con parámetros
        public Categoria(int categoriaId, string nombreCategoria, string estado)
        {
            this.categoriaId = categoriaId;
            this.nombreCategoria = nombreCategoria;
            this.estado = estado;
        }

        // Propiedades
        public int CategoriaId { get =>  categoriaId; set => categoriaId = value; }
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
