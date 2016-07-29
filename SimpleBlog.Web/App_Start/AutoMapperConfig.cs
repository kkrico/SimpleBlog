using AutoMapper;
using SimpleBlog.Core.Mapeamento;

namespace SimpleBlog.Web
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapperCore.RegistrarMapeamentos();
            Mapper.Initialize(cfg =>
            {
               
            });
        }
    }
}