namespace Inspinia_MVC5.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CDASH_USER : DbContext
    {
        public CDASH_USER()
            : base("name=CDASH_USER")
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<SYSUser> SYSUsers { get; set; }
        public virtual DbSet<user> users { get; set; }

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

            modelBuilder.Entity<user>()
                .Property(e => e.FIRSTName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);
        }
    }
}
