using AutoMapper;

namespace SimpleBlog.Core.Mapeamento
{
    public static class AutoMapperCore
    {
        public static void RegistrarMapeamentos()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<PostParaPostTransferObjectProfile>();
            });
        }
    }
}
