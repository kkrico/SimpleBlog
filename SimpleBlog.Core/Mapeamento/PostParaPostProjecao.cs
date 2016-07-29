using AutoMapper;
using SimpleBlog.Core.Projecao;
using SimpleBlog.Dominio.Entidades;

namespace SimpleBlog.Core.Mapeamento
{
    public class PostParaPostProjecao : Profile
    {
        public PostParaPostProjecao()
        {
            CreateMap<Post, PostProjecao>()
                .ForMember(p => p.Tags, config => config.Ignore())
                .ForMember(p => p.Categoria, config => config.Ignore());
        }
    }
}
