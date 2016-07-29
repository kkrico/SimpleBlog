using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleBlog.Data.Infraestrutura;
using SimpleBlog.Data.Repositorio;
using SimpleBlog.Dominio.Entidades;
using SimpleBlog.Test.Fake;
using SimpleBlog.Test.TestUtil;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SimpleBlog.Test.Repositorio
{
    [TestClass]
    public class RepositorioTest
    {
        private Mock<SimpleBlogContext> _mockContext;
        private Mock<DbSet<Post>> _mockSet;

        [TestInitialize]
        public void InicializarMoq()
        {
            _mockContext = new Mock<SimpleBlogContext>("ConnectionString");
            _mockSet = new Mock<DbSet<Post>>();
        }

        [TestMethod]
        public void GetTodosTest()
        {
            var hora = DateTime.Now;
            var data = new List<Post>
            {
                new Post {DataModificacao = hora, DataCriacao = hora, Descricao = "Descricao"},
                new Post {DataModificacao = hora, DataCriacao = hora, Descricao = "Descricao II"},
                new Post {DataModificacao = hora, DataCriacao = hora, Descricao = "Descricao III"}
            }.AsQueryable();

            Util.ConfigurarMock(data, _mockContext);

            var repositorio = new Repositorio<Post>(_mockContext.Object);
            var resultado = repositorio.GetTodos();

            Assert.IsNotNull(resultado);
            Assert.AreEqual(3, resultado.Count());
            Assert.AreEqual(hora, resultado.First().DataModificacao);
            Assert.AreEqual(hora, resultado.Last().DataCriacao);
        }

        [TestMethod]
        public void BuscarComCriterioTest()
        {
            var data = new List<Post>
            {
                new Post { Descricao = "Descricao"},
                new Post {Id = 2, Descricao = "Descricao II"},
                new Post {Id = 1, Descricao = "Descricao III"}
            }.AsQueryable();

            Util.ConfigurarMock(data, _mockContext);

            var repositorio = new Repositorio<Post>(_mockContext.Object);
            var resultado = repositorio.Buscar(p => p.Id != 0);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count());
        }


        [TestMethod]
        public void BuscarTest()
        {
            var data = new List<Post>
            {
                new Post(),
                new Post(),
                new Post(),
                new Post(),
                new Post(),
                new Post(),
                new Post()
            }.AsQueryable();
            Util.ConfigurarMock(data, _mockContext);

            var repo = new Repositorio<Post>(_mockContext.Object);
            var resultado = repo.Buscar(c => c.DataCriacao == DateTime.Now);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(0, resultado.Count());
        }

        [TestMethod]
        public void AdicionarTest()
        {
            var lista = DadosFake.GetPosts().AsQueryable();
            Util.ConfigurarMock(lista, _mockContext, _mockSet);
            
            var repo = new Repositorio<Post>(_mockContext.Object);
            repo.Adicionar(new Post() { Descricao = "Post de exemplo" });
            repo.SalvarAlteracoes();

            _mockSet.Verify(m => m.Add(It.IsAny<Post>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void RemoverTest()
        {
            var lista = DadosFake.GetPosts().AsQueryable().Take(1);
            var entidade = lista.First();
            Util.ConfigurarMock(lista, _mockContext, _mockSet);

            var repo = new Repositorio<Post>(_mockContext.Object);
            repo.Remover(entidade);
            repo.SalvarAlteracoes();

            _mockSet.Verify(m => m.Remove(It.IsAny<Post>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}