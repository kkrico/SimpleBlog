using SimpleBlog.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SimpleBlog.Data.EntityMapping
{
    public class PostsTagsMap : EntityTypeConfiguration<PostsTags>
    {
        public PostsTagsMap()
        {
            ToTable("PostsTags");
            HasKey(p => new { p.PostId, p.TagId });

            Property(p => p.TagId)
                .HasColumnName("TagId")
                .IsRequired();

            Property(p => p.PostId)
                .HasColumnName("PostId")
                .IsRequired();
        }
    }
}