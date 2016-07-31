using System.Collections.Generic;

namespace SimpleBlog.Web.Models
{
    public class PostHomeViewModel
    {
        public PostHomeViewModel()
        {
            Posts = new List<PostViewModel>();
        }

        public int TotalDePosts { get; set; }
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}