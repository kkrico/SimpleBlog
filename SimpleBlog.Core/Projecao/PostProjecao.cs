using System.Collections.Generic;

namespace SimpleBlog.Core.Projecao
{
    public class PostProjecao
    {
        public PostProjecao()
        {
            Posts = new List<PostTransferObject>();
        }

        public int TotalDePosts { get; set; }
        public IEnumerable<PostTransferObject> Posts { get; set; }
    }
}