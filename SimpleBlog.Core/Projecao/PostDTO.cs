using System.Collections.Generic;

namespace SimpleBlog.Core.Projecao
{
    public class PostDTO
    {
        public PostDTO()
        {
            Posts = new List<PostTransferObject>();
        }

        public int TotalDePosts { get; set; }
        public ICollection<PostTransferObject> Posts { get; set; }
    }
}