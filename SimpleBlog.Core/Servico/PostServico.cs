using AutoMapper;
using SimpleBlog.Core.Projecao;
using SimpleBlog.Dominio.Entidades;
using SimpleBlog.Dominio.Repositorios;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SimpleBlog.Core.Servico
{
    public class PostServico : IPostServico
    {
        private readonly IRepositorio<Post> _repositorio;

        public PostServico(IRepositorio<Post> repositorio)
        {
            _repositorio = repositorio;
        }

        public int TotalPosts()
        {
            return _repositorio.GetTodos().Count();
        }

        public IEnumerable<PostTransferObject> PostsPublicados(int numeroPagina = 0, int tamanhoPagina = 10)
        {
            var posts = _repositorio.Buscar(p => p.Publicado)
                .OrderByDescending(p => p.DataPublicacao)
                .Skip(numeroPagina * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToList();

            var poststransferobjects
                = Mapper.Map<IEnumerable<Post>, IEnumerable<PostTransferObject>>(posts);

            return poststransferobjects;
        }
    }
}
