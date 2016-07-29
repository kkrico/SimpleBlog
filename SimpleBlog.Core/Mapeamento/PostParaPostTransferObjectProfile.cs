using AutoMapper;
using SimpleBlog.Core.Projecao;
using SimpleBlog.Dominio.Entidades;

namespace SimpleBlog.Core.Mapeamento
{
    public class PostParaPostTransferObjectProfile : Profile
    {
        public PostParaPostTransferObjectProfile()
        {
            CreateMap<Post, PostTransferObject>()
                .ForMember(p => p.Tags, config => config.Ignore())
                .ForMember(p => p.Categoria, config => config.Ignore());
        }
    }
}
