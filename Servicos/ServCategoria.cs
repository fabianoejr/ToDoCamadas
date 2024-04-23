using Entidades;
using Repositorio;
using System.Security.Cryptography;
using System.Text;

namespace Servicos
{
    public interface IServCategoria
    {
        List<Categorias> BuscarTodasCategorias();
        Categorias BuscarCategoria(int id);
        void Inserir(InserirCategoriaDTO inserirCategoriaDto);
        void Remover(int id);
    }

    public class ServCategoria : IServCategoria
    {
        private IRepoCategoria _repoCategoria;

        public ServCategoria(IRepoCategoria repoCategoria)
        {
            _repoCategoria = repoCategoria;
        }

        public void Inserir(InserirCategoriaDTO inserirCategoriaDto)
        {
            var categoria = new Categorias();

            categoria.Nome = inserirCategoriaDto.Nome;

            _repoCategoria.Inserir(categoria);
        }

        public List<Categorias> BuscarTodasCategorias()
        {
            var categorias = _repoCategoria.BuscarTodasCategorias();

            return categorias;
        }

        public Categorias BuscarCategoria(int id)
        {
            return _repoCategoria.BuscarTodasCategorias().Where(p => p.Id == id).FirstOrDefault();
        }

        public void Remover(int id)
        {
            var categoria = _repoCategoria.BuscarTodasCategorias().Where(p => p.Id == id).FirstOrDefault();

            _repoCategoria.Remover(categoria);
        }
    }
}