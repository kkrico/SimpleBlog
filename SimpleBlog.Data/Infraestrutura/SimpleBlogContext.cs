using SimpleBlog.Dominio.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SimpleBlog.Data.Infraestrutura
{
    public class SimpleBlogContext: DbContext
    {
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostsTags> PostTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        public SimpleBlogContext(string nameOrConnectionstring) : base(nameOrConnectionstring)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
