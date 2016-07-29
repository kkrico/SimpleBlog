using SimpleBlog.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SimpleBlog.Data.EntityMapping
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria");

            Property(p => p.Descricao)
                .HasMaxLength(200);

            Property(p => p.Nome)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.UrlSlug)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}