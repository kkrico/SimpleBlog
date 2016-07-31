using SimpleBlog.Web.CustomActionResult;
using System.Web.Mvc;

namespace SimpleBlog.Web.Controllers
{
    public class BaseController : Controller
    {
        protected PostResult PostView()
        {
            return new PostResult(null, null, null);
        }

        protected PostResult PostView(string nomeView)
        {
            return new PostResult(nomeView, null, null);
        }

        protected PostResult PostView(string nomeView, string nomePartial)
        {
            return new PostResult(nomeView, nomePartial, null);
        }

        protected PostResult PostView(string nomeView, string nomePartial, object data)
        {
            return new PostResult(nomeView, nomePartial, data);
        }
    }
}