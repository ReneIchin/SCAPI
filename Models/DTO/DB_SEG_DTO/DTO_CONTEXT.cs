using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DTO.DB_SEG_DTO
{
    public partial class DTO_CONTEXT : DbContext
    {
        public DTO_CONTEXT(DbContextOptions<DTO_CONTEXT> options)
       : base(options)
        {
        }

        public virtual DbSet<GET_SISTEMA_MODULO> GET_SISTEMA_MODULO { get; set; }
        public virtual DbSet<C_MODULO_DTO> C_MODULO_DTO { get; set; }
        public virtual DbSet<DATOS_RESUM_USUARIO> DATOS_RESUM_USUARIO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GET_SISTEMA_MODULO>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.SISTEMA_ID).ValueGeneratedNever();
                entity.Property(e => e.GRUPO_MODULO_ID).ValueGeneratedNever();
            });

            modelBuilder.Entity<C_MODULO_DTO>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.SISTEMA_ID).ValueGeneratedNever();
                entity.Property(e => e.GRUPO_MODULO_ID).ValueGeneratedNever();
            });

            modelBuilder.Entity<DATOS_RESUM_USUARIO>(entity =>
            {
                entity.HasNoKey();
            });

        }


    }
}
