namespace WebsiteRapChieuPhim.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    public partial class admincontext : DbContext
    {
        public admincontext()
            : base("name=admincontext")
        {
        }
        public virtual DbSet<admindd> Users { get; set; }

       
           
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admindd>()
              .Property(e => e.username)
              .IsUnicode(false);

            modelBuilder.Entity<admindd>()
                .Property(e => e.password)
                .IsUnicode(false);
           
        }

        public long InsertForFacebook(admindd entity)
        {
            var user = Users.SingleOrDefault(x => x.username == entity.username);
            if (user == null)
            {
                Users.Add(entity);
                SaveChanges();
                return entity.Id;
            }
            else
            {
                return user.Id;
            }

        }
    }
}