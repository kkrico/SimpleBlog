using SimpleBlog.Dominio.Entidades;
using System.Collections.Generic;

namespace SimpleBlog.Test.Fake
{
    public class DadosFalsos
    {
        public static IEnumerable<Post> GetPosts()
        {
            return new List<Post>()
            {
                new Post(),
                new Post(),
                new Post(),
                new Post(),
                new Post(),
                new Post(),
                new Post(),
                new Post(),
                new Post(),
                new Post(),
                new Post(),
                new Post(),
                new Post(),
            };
        }
    }
}
