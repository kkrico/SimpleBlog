using SimpleBlog.Core.Servico;
using System.Web.Mvc;

namespace SimpleBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostServico _servico;

        public HomeController(IPostServico servico)
        {
            _servico = servico;
        }

        // GET: Home
        public ActionResult Index()
        {
            var postsProjecao = _servico.GetPosts(1, 1);

            return View("Index");
        }
    }
}