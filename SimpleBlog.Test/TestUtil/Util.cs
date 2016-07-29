using Moq;
using SimpleBlog.Data.Infraestrutura;
using System.Data.Entity;
using System.Linq;

namespace SimpleBlog.Test.TestUtil
{
    public static class Util
    {
        #region Método utilitário
        public static void ConfigurarMock<T>(IQueryable<T> data, Mock<SimpleBlogContext> mockContext, Mock<DbSet<T>> mockset = null) where T : class
        {
            if (mockset == null)
                mockset = new Mock<DbSet<T>>();

            mockset.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockset.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockset.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockset.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockContext.Setup(m => m.Set<T>()).Returns(mockset.Object);
        }
        #endregion
    }
}
