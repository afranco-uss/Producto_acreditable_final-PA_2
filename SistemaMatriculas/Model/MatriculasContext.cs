namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MatriculasContext : DbContext
    {
        public MatriculasContext()
            : base("name=MatriculasContext")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<T_GENM_ALUMNO> T_GENM_ALUMNO { get; set; }
        public virtual DbSet<T_GENM_ASIGNATURA> T_GENM_ASIGNATURA { get; set; }
        public virtual DbSet<T_GENM_AULA> T_GENM_AULA { get; set; }
        public virtual DbSet<T_GENM_GRUPO> T_GENM_GRUPO { get; set; }
        public virtual DbSet<T_GENM_MATRICULA> T_GENM_MATRICULA { get; set; }
        public virtual DbSet<T_GENM_NOTA> T_GENM_NOTA { get; set; }
        public virtual DbSet<T_GENM_PERSONA> T_GENM_PERSONA { get; set; }
        public virtual DbSet<T_GENM_USUARIO> T_GENM_USUARIO { get; set; }
        public virtual DbSet<T_MAE_CICLO_PLAN> T_MAE_CICLO_PLAN { get; set; }
        public virtual DbSet<T_MAE_SEMESTRE> T_MAE_SEMESTRE { get; set; }
        public virtual DbSet<T_MAE_TIPO_ASIGNATURA> T_MAE_TIPO_ASIGNATURA { get; set; }
        public virtual DbSet<T_MAE_TIPO_EVALUACION> T_MAE_TIPO_EVALUACION { get; set; }
        public virtual DbSet<T_MAE_TIPO_USUARIO> T_MAE_TIPO_USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_GENM_ALUMNO>()
                .Property(e => e.CODIGO)
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_ALUMNO>()
                .Property(e => e.SEMESTRE_INGRESO)
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_ALUMNO>()
                .Property(e => e.FLG_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_ALUMNO>()
                .HasMany(e => e.T_GENM_MATRICULA)
                .WithRequired(e => e.T_GENM_ALUMNO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_GENM_ALUMNO>()
                .HasMany(e => e.T_GENM_NOTA)
                .WithRequired(e => e.T_GENM_ALUMNO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_GENM_ASIGNATURA>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_ASIGNATURA>()
                .Property(e => e.FLG_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_ASIGNATURA>()
                .HasMany(e => e.T_GENM_NOTA)
                .WithRequired(e => e.T_GENM_ASIGNATURA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_GENM_AULA>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_AULA>()
                .Property(e => e.FLG_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_AULA>()
                .HasMany(e => e.T_GENM_GRUPO)
                .WithRequired(e => e.T_GENM_AULA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_GENM_GRUPO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_GRUPO>()
                .Property(e => e.FLG_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_GRUPO>()
                .HasMany(e => e.T_GENM_MATRICULA)
                .WithRequired(e => e.T_GENM_GRUPO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_GENM_MATRICULA>()
                .Property(e => e.CODIGO_MATRICULA)
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_MATRICULA>()
                .Property(e => e.FLG_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_NOTA>()
                .Property(e => e.FLG_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_PERSONA>()
                .Property(e => e.NOMBRES)
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_PERSONA>()
                .Property(e => e.APELLIDO_PATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_PERSONA>()
                .Property(e => e.APELLIDO_MATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_PERSONA>()
                .Property(e => e.MAIL)
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_PERSONA>()
                .Property(e => e.NRO_TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_PERSONA>()
                .Property(e => e.SEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_PERSONA>()
                .Property(e => e.FLG_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_PERSONA>()
                .Property(e => e.DNI)
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_PERSONA>()
                .HasMany(e => e.T_GENM_ALUMNO)
                .WithRequired(e => e.T_GENM_PERSONA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_GENM_PERSONA>()
                .HasMany(e => e.T_GENM_USUARIO)
                .WithRequired(e => e.T_GENM_PERSONA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_GENM_USUARIO>()
                .Property(e => e.FLG_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_USUARIO>()
                .Property(e => e.NOMBRE_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<T_GENM_USUARIO>()
                .Property(e => e.CONTRASENA)
                .IsUnicode(false);

            modelBuilder.Entity<T_MAE_CICLO_PLAN>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<T_MAE_CICLO_PLAN>()
                .Property(e => e.FLG_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_MAE_CICLO_PLAN>()
                .HasMany(e => e.T_GENM_ASIGNATURA)
                .WithRequired(e => e.T_MAE_CICLO_PLAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_MAE_SEMESTRE>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<T_MAE_SEMESTRE>()
                .Property(e => e.FLG_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_MAE_SEMESTRE>()
                .HasMany(e => e.T_GENM_MATRICULA)
                .WithRequired(e => e.T_MAE_SEMESTRE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_MAE_TIPO_ASIGNATURA>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<T_MAE_TIPO_ASIGNATURA>()
                .Property(e => e.FLG_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_MAE_TIPO_ASIGNATURA>()
                .HasMany(e => e.T_GENM_ASIGNATURA)
                .WithRequired(e => e.T_MAE_TIPO_ASIGNATURA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_MAE_TIPO_EVALUACION>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<T_MAE_TIPO_EVALUACION>()
                .Property(e => e.FLG_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_MAE_TIPO_EVALUACION>()
                .HasMany(e => e.T_GENM_NOTA)
                .WithRequired(e => e.T_MAE_TIPO_EVALUACION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_MAE_TIPO_USUARIO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<T_MAE_TIPO_USUARIO>()
                .Property(e => e.FLG_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_MAE_TIPO_USUARIO>()
                .HasMany(e => e.T_GENM_USUARIO)
                .WithRequired(e => e.T_MAE_TIPO_USUARIO)
                .WillCascadeOnDelete(false);
        }
    }
}
