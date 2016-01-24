using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarkdownManager.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MarkdownManager.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ApplicationDbContext")
        {

        }

        public DbSet<MyUser> MyUsers { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}