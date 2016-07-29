using SimpleBlog.Core.Projecao;
using System.Collections.Generic;

namespace SimpleBlog.Web.Models
{
    public class PostViewModel
    {
        public PostViewModel()
        {
            Posts = new List<PostProjecao>();
        }

        public int TotalDePosts { get; set; }
        public ICollection<PostProjecao> Posts { get; set; }
    }
}