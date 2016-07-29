using System;
using System.Collections.Generic;

namespace SimpleBlog.Core.Projecao
{
    public class PostProjecao
    {
        public PostProjecao()
        {
            Tags = new List<TagsProjecao>();
        }

        public virtual string Titulo
        { get; set; }

        public virtual string DescricaoCurta
        { get; set; }

        public virtual string Descricao
        { get; set; }

        public virtual string UrlSlug
        { get; set; }

        public virtual bool Publicado
        { get; set; }

        public virtual DateTime DataPublicacao
        { get; set; }

        public virtual CategoriaProjecao Categoria
        { get; set; }

        public ICollection<TagsProjecao> Tags { get; set; }
    }
}