using SimpleBlog.Web.CustomActionResult;
using System.Web.Mvc;

namespace SimpleBlog.Web.Controllers
{
    public class BaseController : Controller
    {
        protected PostsResult Posts()
        {
            return new PostsResult(null, null, null);
        }

        protected PostsResult Posts(string nomeView)
        {
            return new PostsResult(nomeView, null, null);
        }

        protected PostsResult Posts(string nomeView, string nomePartial)
        {
            return new PostsResult(nomeView, nomePartial, null);
        }

        protected PostsResult Posts(string nomeView, string nomePartial, object data)
        {
            return new PostsResult(nomeView, nomePartial, data);
        }
    }
}