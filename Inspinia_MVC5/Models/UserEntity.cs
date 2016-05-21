namespace Inspinia_MVC5.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserEntity : DbContext
    {
        public UserEntity()
            : base("name=UserEntity")
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<SYSUser> SYSUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SYSUser>()
                .Property(e => e.LoginName)
                .IsUnicode(false);

            modelBuilder.Entity<SYSUser>()
                .Property(e => e.PasswordEncryptedText)
                .IsUnicode(false);

            modelBuilder.Entity<SYSUser>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<SYSUser>()
                .Property(e => e.role)
                .IsUnicode(false);

          
        }
    }
}
