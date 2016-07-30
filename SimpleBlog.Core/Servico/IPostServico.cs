using SimpleBlog.Core.Projecao;

namespace SimpleBlog.Core.Servico
{
    public interface IPostServico
    {
        int TotalDePosts();
        PostProjecao GetPosts(int pageNo, int pageSize);
    }
}