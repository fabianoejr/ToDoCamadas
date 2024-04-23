using Entidades;

namespace Repositorio
{
    public interface IRepoCategoria
    {
        void Inserir(Categorias categoria);
        List<Categorias> BuscarTodasCategorias();
        Categorias BuscarCategoria(int id);
        void Remover(Categorias categoria);
    }
    public class RepoCategoria : IRepoCategoria
    {
        private DataContext _dataContext;

        public RepoCategoria(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Categorias categoria)
        {
            _dataContext.Add(categoria);

            _dataContext.SaveChanges();
        }

        public List<Categorias> BuscarTodasCategorias()
        {
            var categorias = _dataContext.Categoria.ToList();

            return categorias;
        }

        public Categorias BuscarCategoria(int id)
        {
            var categoria = _dataContext.Categoria.FirstOrDefault(u => u.Id == id);

            return categoria;
        }

        public void Remover(Categorias categoria)
        {
            _dataContext.Remove(categoria);

            _dataContext.SaveChanges();
        }
    }
}
