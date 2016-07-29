using System.Collections.Generic;

namespace SimpleBlog.Dominio.Entidades
{
    public class Categoria
    {
        public virtual int Id
        { get; set; }

        public virtual string Nome
        { get; set; }

        public virtual string UrlSlug
        { get; set; }

        public virtual string Descricao
        { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}