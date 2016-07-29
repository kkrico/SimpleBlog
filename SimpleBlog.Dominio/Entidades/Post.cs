using System;
using System.Collections.Generic;

namespace SimpleBlog.Dominio.Entidades
{
    public class Post
    {
        public virtual int Id
        { get; set; }

        public virtual string Titulo
        { get; set; }

        public virtual string DescricaoCurta
        { get; set; }

        public virtual string Descricao
        { get; set; }

        public virtual string Meta
        { get; set; }

        public virtual string UrlSlug
        { get; set; }

        public virtual bool Publicado
        { get; set; }

        public virtual DateTime DataPublicacao
        { get; set; }

        public virtual DateTime DataCriacao
        { get; set; }

        public virtual DateTime? DataModificacao
        { get; set; }

        public virtual Categoria Categoria
        { get; set; }

        public virtual int CategoriaId { get; set; }

        public ICollection<PostsTags> PostsTags { get; set; }
    }
}
