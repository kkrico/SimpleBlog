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

        public int TotalDePosts()
        {
            return _repositorio.GetTodos().Count();
        }

        public PostProjecao GetPosts(int numeroPagina = 0, int tamanhoPagina = 10)
        {
            var posts = _repositorio.Buscar(p => p.Publicado)
                .OrderByDescending(p => p.DataPublicacao)
                .Skip(numeroPagina * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToList();

            var postsTransferObject
                = Mapper.Map<ICollection<Post>, ICollection<PostTransferObject>>(posts);
            var resultado = new PostProjecao
            {
                TotalDePosts = TotalDePosts(),
                Posts = postsTransferObject
            };

            return resultado;
        }
    }
}
