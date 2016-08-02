using SimpleBlog.Core.Servico;
using System.Web.Mvc;

namespace SimpleBlog.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPostServico _servico;

        public HomeController(IPostServico servico)
        {
            _servico = servico;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Posts(int pagina = 1)
        {
            return Posts("Posts", "PostsPartialView", new { Data = "Data de exemplo" });
        }
    }
}