using DataAccess.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContexts
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<System_Language> System_Language { get; set; }
        public DbSet<Lookup_Category> Lookup_Category { get; set; }
        public DbSet<System_Lookup> System_Lookup { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Paint> Paint { get; set; }
        public DbSet<Paint_Detail> Paint_Detail { get; set; }
        public DbSet<Dimension> Dimension { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder = OnModelCreateKeys(modelBuilder);
            modelBuilder = OnModelCreateRelations(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private ModelBuilder OnModelCreateKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<System_Language>().HasKey(x => x.ID);
            modelBuilder.Entity<System_Language>().Property(x => x.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Lookup_Category>().HasKey(x => x.ID);
            modelBuilder.Entity<Lookup_Category>().Property(x => x.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<System_Lookup>().HasKey(x => x.ID);
            modelBuilder.Entity<System_Lookup>().Property(x => x.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Role>().HasKey(x => x.ID);
            modelBuilder.Entity<Role>().Property(x => x.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>().HasKey(x => x.ID);
            modelBuilder.Entity<User>().Property(x => x.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(x => x.IsActive).HasDefaultValue(false);
            modelBuilder.Entity<User>().HasIndex(x => x.Username).IsUnique();
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();

            modelBuilder.Entity<Paint>().HasKey(x => x.ID);
            modelBuilder.Entity<Paint>().Property(x => x.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Paint>().HasIndex(x => x.NameSLID).IsUnique();

            modelBuilder.Entity<Paint_Detail>().HasKey(x => x.ID);
            modelBuilder.Entity<Paint_Detail>().Property(x => x.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Dimension>().HasKey(x => x.ID);
            modelBuilder.Entity<Dimension>().Property(x => x.ID).ValueGeneratedOnAdd();

            return modelBuilder;
        }

        private ModelBuilder OnModelCreateRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<System_Language>()
                .HasOne(x => x.User)
                .WithMany(x => x.LstSystemLanguages)
                .HasForeignKey(x => x.CreatedBy);

            modelBuilder.Entity<System_Lookup>()
                .HasOne(x => x.LookupCategory)
                .WithMany(x => x.LstSystemLookups)
                .HasForeignKey(x => x.LookupCategoryID);

            modelBuilder.Entity<User>()
                .HasOne(x => x.Role)
                .WithMany(x => x.LstUsers)
                .HasForeignKey(x => x.RoleID);

            modelBuilder.Entity<Paint>()
                .HasOne(x => x.User)
                .WithMany(x => x.LstPaints)
                .HasForeignKey(x => x.UserID);
            modelBuilder.Entity<Paint>()
                .HasOne(x => x.Name)
                .WithOne(x => x.Paint)
                .HasForeignKey<Paint>(x => x.NameSLID);

            modelBuilder.Entity<Paint_Detail>()
                .HasOne(x => x.Paint)
                .WithOne(x => x.PaintDetail)
                .HasForeignKey<Paint_Detail>(x => x.PaintID);
            modelBuilder.Entity<Paint_Detail>()
                .HasOne(x => x.Dimension)
                .WithMany(x => x.LstPaintDetails)
                .HasForeignKey(x => x.DimensionID);
            modelBuilder.Entity<Paint_Detail>()
                .HasOne(x => x.Category)
                .WithMany(x => x.LstPaintDetailsOnCategory)
                .HasForeignKey(x => x.CategoryLKPID);
            modelBuilder.Entity<Paint_Detail>()
                .HasOne(x => x.Status)
                .WithMany(x => x.LstPaintDetailsOnStatus)
                .HasForeignKey(x => x.StatusLKPID);
            modelBuilder.Entity<Paint_Detail>()
                .HasOne(x => x.Glass)
                .WithMany(x => x.LstPaintDetailsOnGlass)
                .HasForeignKey(x => x.GlassLKPID);
            modelBuilder.Entity<Paint_Detail>()
                .HasOne(x => x.Frame)
                .WithMany(x => x.LstPaintDetailsOnFrame)
                .HasForeignKey(x => x.FrameLKPID);

            return modelBuilder;
        }
    }
}
