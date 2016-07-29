namespace SimpleBlog.Core.Projecao
{
    public class CategoriaProjecao
    {
        public virtual string Nome
        { get; set; }

        public virtual string UrlSlug
        { get; set; }

        public virtual string Descricao
        { get; set; }
    }
}