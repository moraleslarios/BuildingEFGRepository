namespace BuildingEFGRepository.DataBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDBEntities : DbContext
    {
        public MyDBEntities()
            : base("name=MyDBEntities")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<FootballClub> FootballClubs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FootballClub>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FootballClub>()
                .Property(e => e.Members)
                .HasPrecision(18, 0);
        }
    }
}
