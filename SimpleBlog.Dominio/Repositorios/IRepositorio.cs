using System;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleBlog.Dominio.Repositorios
{
    public interface IRepositorio<TEntidade> where TEntidade : class
    {
        IQueryable<TEntidade> GetTodos();
        IQueryable<TEntidade> Buscar(Expression<Func<TEntidade,
                                bool>> criterio,
                                Func<TEntidade, object> ordenarPor = null,
                                params Expression<Func<TEntidade, object>>[] propriedadesDeNavegacao);

        IQueryable<TEntidade> GetPaginado(int skip, int take);
        void Adicionar(TEntidade entidade);
        void Remover(TEntidade entidade);
        void Atualizar(TEntidade entidade);
        void SalvarAlteracoes();
    }
}
