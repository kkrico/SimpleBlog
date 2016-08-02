using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleBlog.Core.Servico;
using SimpleBlog.Data.Infraestrutura;
using SimpleBlog.Data.Repositorio;
using SimpleBlog.Dominio.Entidades;
using SimpleBlog.Web.Controllers;
using SimpleBlog.Web.CustomActionResult;
using System.Web.Mvc;

namespace SimpleBlog.Test.Controllers
{
    [TestClass()]
    public class HomeControllerTest
    {

        private Mock<SimpleBlogContext> _mockContext;
        private HomeController _controller;

        [TestInitialize]
        public void InicializarMoq()
        {
            _mockContext = new Mock<SimpleBlogContext>("ConnectionString");
            _controller = new HomeController(new PostServico(new Repositorio<Post>(_mockContext.Object)));
        }

        [TestMethod()]
        public void IndexTest()
        {
            var resultado = _controller.Index() as ViewResult;

            Assert.IsNotNull(resultado);
            Assert.AreEqual("Index", resultado.ViewName);
        }

        [TestMethod]
        public void IndexRetornaSemErroModelState()
        {
            var index  = _controller.Index() as ViewResult;

            Assert.IsNotNull(index);
            Assert.AreEqual(true, index.ViewData.ModelState.IsValid);
        }


        [TestMethod()]
        public void PostsTest()
        {
            var posts = _controller.Posts() as PostsResult;

            Assert.IsNotNull(posts);
            Assert.AreEqual("Posts", posts.ViewName);
        }


        [TestMethod()]
        public void PostsComModelTest()
        {
            var posts = _controller.Posts() as PostsResult;

            Assert.IsNotNull(posts);
            Assert.IsNotNull(posts.Model);
        }
    }
}