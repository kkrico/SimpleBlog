using SimpleBlog.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SimpleBlog.Data.EntityMapping
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            ToTable("Post");

            HasKey(p => p.Id);

            Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(p => p.Titulo)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.DescricaoCurta)
                .HasMaxLength(200);

            Property(p => p.Descricao)
                .HasMaxLength(5000);

            Property(p => p.Meta)
                .HasMaxLength(1000)
                .IsRequired();

            Property(p => p.UrlSlug)
                .HasMaxLength(200)
                .IsRequired();

            Property(p => p.Publicado)
                .IsRequired();

            Property(p => p.DataPublicacao)
                .IsRequired();

            Property(p => p.DataCriacao)
                .IsRequired();

            Property(p => p.CategoriaId)
                .HasColumnName("CategoriaId");
        }
    }
}
