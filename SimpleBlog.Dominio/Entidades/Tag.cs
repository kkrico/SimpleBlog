namespace SimpleBlog.Dominio.Entidades
{
    public class Tag
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string UrlSlug { get; set; }
        public virtual string Descricao { get; set; }
    }
}
