using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleBlog.Core.Mapeamento;
using SimpleBlog.Core.Servico;
using SimpleBlog.Data.Infraestrutura;
using SimpleBlog.Data.Repositorio;
using SimpleBlog.Dominio.Entidades;
using SimpleBlog.Test.TestUtil;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlog.Test.Servico
{
    [TestClass()]
    public class PostServicoTest
    {
        private Mock<SimpleBlogContext> _mockContext;

        [TestInitialize]
        public void InicializarMoq()
        {
            _mockContext = new Mock<SimpleBlogContext>("ConnectionString");
            AutoMapperCore.RegistrarMapeamentos();
        }

        [TestMethod]
        public void GetTodosPostsTest()
        {
            var data = new List<Post>
            {
                new Post() { },
                new Post() { },
                new Post() { },
                new Post() { },
                new Post() { },
                new Post() { },
            }.AsQueryable();
            Util.ConfigurarMock(data, _mockContext);

            var servico = new PostServico(new Repositorio<Post>(_mockContext.Object));
            var resultado = servico.TotalDePosts();

            Assert.AreEqual(6, resultado);
        }

        [TestMethod]
        public void GetTodosOsPostsPublicados()
        {
            var data = new List<Post>
            {
                new Post() { Publicado = true },
                new Post() { },
                new Post() { Publicado = true },
                new Post() { },
                new Post() { },
                new Post() { },
            }.AsQueryable();
            Util.ConfigurarMock(data, _mockContext);

            var servico = new PostServico(new Repositorio<Post>(_mockContext.Object));
            var resultado = servico.GetPosts();

            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.TotalDePosts);
        }
    }
}