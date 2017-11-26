namespace BuildingEFGRepository.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GeneralEntities : DbContext
    {
        public GeneralEntities()
            : base("name=GeneralEntities")
        {
        }

        public virtual DbSet<CKES_ENTIDADES> CKES_ENTIDADES { get; set; }
        public virtual DbSet<CKES_USUARIOS_PANORAMA> CKES_USUARIOS_PANORAMA { get; set; }
        public virtual DbSet<CKES_ENTIDADES_CONTACTOS> CKES_ENTIDADES_CONTACTOS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CKES_ENTIDADES>()
                .Property(e => e.IdEntidad)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CKES_ENTIDADES>()
                .Property(e => e.PrefijoVPD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CKES_ENTIDADES>()
                .Property(e => e.HabilitaSubentidad)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CKES_USUARIOS_PANORAMA>()
                .Property(e => e.IdEntidad)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CKES_ENTIDADES_CONTACTOS>()
                .Property(e => e.IdEntidad)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CKES_ENTIDADES_CONTACTOS>()
                .Property(e => e.Telefono1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CKES_ENTIDADES_CONTACTOS>()
                .Property(e => e.Telefono2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CKES_ENTIDADES_CONTACTOS>()
                .Property(e => e.cargo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CKES_ENTIDADES_CONTACTOS>()
                .Property(e => e.CITRIX_Maquina)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CKES_ENTIDADES_CONTACTOS>()
                .Property(e => e.IdDepartamento)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
