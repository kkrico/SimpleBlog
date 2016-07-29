using SimpleBlog.Core.Projecao;

namespace SimpleBlog.Core.Servico
{
    public interface IPostServico
    {
        int TotalDePosts();
        PostDTO GetPosts(int pageNo, int pageSize);
    }
}