using System.Collections.Generic;

namespace SimpleBlog.Core.Projecao
{
    public class PostDTO
    {
        public PostDTO()
        {
            Posts = new List<PostProjecao>();
        }

        public int TotalDePosts { get; set; }
        public ICollection<PostProjecao> Posts { get; set; }
    }
}