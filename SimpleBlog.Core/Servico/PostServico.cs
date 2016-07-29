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

        public PostDTO GetPosts(int pageNo = 0, int pageSize = 10)
        {
            var posts = _repositorio.Buscar(p => p.Publicado)
                .Skip(pageNo * pageSize)
                .Take(pageSize)
                .ToList();

            var postsp = Mapper.Map<ICollection<Post>, ICollection<PostTransferObject>>(posts);
            var resultado = new PostDTO
            {
                TotalDePosts = posts.Count
            };

            return resultado;
        }
    }
}
