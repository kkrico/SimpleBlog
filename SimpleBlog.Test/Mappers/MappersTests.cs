using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleBlog.Core.Mapeamento;
using SimpleBlog.Core.Projecao;
using SimpleBlog.Dominio.Entidades;

namespace SimpleBlog.Test.Mappers
{
    [TestClass]
    public class MappersTests
    {
        [TestMethod]
        public void PostParaPostProjecao()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostProjecao>();
                cfg.AddProfile<PostParaPostTransferObject>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}
