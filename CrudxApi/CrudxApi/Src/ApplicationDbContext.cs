using System;
using CrudxApi.Src.Crud;
using CrudxApi.Src.CrudStatic;
using CrudxApi.Src.FieldType;
using CrudxApi.Src.File;
using CrudxApi.Src.Project;
using CrudxApi.Src.Technology;
using Microsoft.EntityFrameworkCore;

namespace CrudxApi.Src
{
	public class ApplicationDbContext : DbContext
    {
        public DbSet<TechnologyModel> Technologies { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<CrudStaticModel> CrudStatics { get; set; }
        public DbSet<CrudModel> Cruds { get; set; }
        public DbSet<FieldModel> Fields { get; set; }
        public DbSet<FieldTypeModel> FieldTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    modelBuilder.Entity<FileModel>()
            //        .HasOne(f => f.Technology)
            //        .WithMany(t => t.Files)
            //        .HasForeignKey(f => f.TechnologyId);
        }
    }
}

