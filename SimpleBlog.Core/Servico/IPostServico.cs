using SimpleBlog.Core.Projecao;
using System.Collections.Generic;

namespace SimpleBlog.Core.Servico
{
    public interface IPostServico
    {
        int TotalPosts();
        IEnumerable<PostTransferObject> PostsPublicados(int numeroPagina = 0, int tamanhoPagina = 10);
    }
}