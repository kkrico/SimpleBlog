using SimpleBlog.Data.Infraestrutura;
using SimpleBlog.Dominio.Repositorios;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleBlog.Data.Repositorio
{
    public class Repositorio<TEntidade> : IRepositorio<TEntidade> where TEntidade : class
    {
        private readonly DbSet<TEntidade> _set;
        private readonly SimpleBlogContext _contexto;

        public Repositorio(SimpleBlogContext contexto)
        {
            _contexto = contexto;
            _set = _contexto.Set<TEntidade>();
        }

        public Repositorio(string connectionString)
        {
            _contexto = new SimpleBlogContext(connectionString);
            _set = _contexto.Set<TEntidade>();
        }

        public IQueryable<TEntidade> GetTodos()
        {
            return _set;
        }

        public IQueryable<TEntidade> Buscar(Expression<Func<TEntidade, bool>> criterio, Func<TEntidade, object> ordenarPor = null, params Expression<Func<TEntidade, object>>[] propriedadesDeNavegacao)
        {
            IncluirPropriedadesNaQuery(propriedadesDeNavegacao, _set);

            IQueryable<TEntidade> resultado = ordenarPor != null ?
                _set.Where(criterio).OrderBy(ordenarPor).AsQueryable() :
                _set.Where(criterio).AsQueryable();

            return resultado;
        }

        public IQueryable<TEntidade> GetPaginado(int skip, int take)
        {
            return _set.Skip(skip).Take(take);
        }

        public void Adicionar(TEntidade entidade)
        {
            _set.Add(entidade);
        }

        public void Remover(TEntidade entidade)
        {
            _set.Remove(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            var entry = _contexto.Entry(entidade);
            if (entry.State == EntityState.Detached)
            {
                _set.Attach(entidade);
                entry = _contexto.Entry(entidade);
            }
            entry.State = EntityState.Modified;
        }

        public void SalvarAlteracoes()
        {
            _contexto.SaveChanges();
        }

        #region Método utilitário
        private void IncluirPropriedadesNaQuery(Expression<Func<TEntidade, object>>[] propriedadesDeNavegacao, IQueryable<TEntidade> entidade)
        {
            propriedadesDeNavegacao.Aggregate(entidade, (current, propriedade) => current.Include(propriedade));
        }

        #endregion
    }
}
