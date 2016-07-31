using System;
using SimpleBlog.Dominio.Entidades;

namespace SimpleBlog.Web.Models
{
    public class PostViewModel
    {
        public virtual string Titulo
        { get; set; }

        public virtual string DescricaoCurta
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
    }
}