using Preinscripcion.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Preinscripcion.AccesoDatos.Context
{
    public class PreinscripcionContext : DbContext
    {
        public PreinscripcionContext() : base("PreinscripcionContext") //Lo que está entre " " es el Connection String que se agrega al archivo Web.config
        {
            //solo funciona en aquellas properties declaradas como virtual
            Configuration.LazyLoadingEnabled = true;

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PreinscripcionContext>());
        }
        //Lo que está entre < > se refiere a que le puedo hacer querys a esa tabla y lo que sigue es el nombre de la tabla, ej: tabla Alerta y c/ fila es una Alerta.
        public virtual DbSet<Administrativo> Administrativo { get; set; }
        public virtual DbSet<Alumno> Alumno { get; set; }   //virtual use lazy mode
        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivil { get; set; }
        public virtual DbSet<Localidad> Localidad { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<PreinscripcionOnline> PreinscripcionOnline { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<TipoDoc> TipoDoc { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Apunte>().HasKey(obj => new { obj.Id, obj.Nr });
            //modelBuilder.Ignore<Item>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        //public DbSet<Entidades.Shared.Archivo> Archivos { get; set; }
    }
}




