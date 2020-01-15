using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieX.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MovieXConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Movie> Movies { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);



        //    modelBuilder.Entity<Chat>()
        //                .HasRequired(m => m.Sender)
        //                .WithMany(s => s.Chats)
        //                .HasForeignKey(m => m.
        //)
        //                .WillCascadeOnDelete(true);



        //    modelBuilder.Entity<Chat>()
        //                .HasRequired(m => m.Receiver)
        //                .WithMany()
        //                .HasForeignKey(m => m.ReceiverId)
        //                .WillCascadeOnDelete(false);
        //}
    }
}