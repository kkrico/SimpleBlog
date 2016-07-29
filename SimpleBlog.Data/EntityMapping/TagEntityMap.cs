using SimpleBlog.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SimpleBlog.Data.EntityMapping
{
    public class TagEntityMap : EntityTypeConfiguration<Tag>
    {
        public TagEntityMap()
        {
            ToTable("Tag");

            Property(t => t.Descricao)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}