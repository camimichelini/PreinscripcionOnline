namespace Preinscripcion.AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrativo",
                c => new
                    {
                        AdministrativoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        NroDoc = c.Int(nullable: false),
                        Usuario = c.String(),
                        Contraseña = c.String(),
                        TipoDoc_TipoDocId = c.Int(),
                    })
                .PrimaryKey(t => t.AdministrativoId)
                .ForeignKey("dbo.TipoDoc", t => t.TipoDoc_TipoDocId)
                .Index(t => t.TipoDoc_TipoDocId);
            
            CreateTable(
                "dbo.TipoDoc",
                c => new
                    {
                        TipoDocId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoDocId);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        PersonaId = c.Long(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        TipoDocId = c.Int(nullable: false),
                        NroDoc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonaId)
                .ForeignKey("dbo.TipoDoc", t => t.TipoDocId, cascadeDelete: true)
                .Index(t => t.TipoDocId);
            
            CreateTable(
                "dbo.Carrera",
                c => new
                    {
                        CarreraId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.CarreraId);
            
            CreateTable(
                "dbo.EstadoCivil",
                c => new
                    {
                        EstadoCivilId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.EstadoCivilId);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        LocalidadId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Provincia_ProvinciaId = c.Int(),
                    })
                .PrimaryKey(t => t.LocalidadId)
                .ForeignKey("dbo.Provincia", t => t.Provincia_ProvinciaId)
                .Index(t => t.Provincia_ProvinciaId);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        ProvinciaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Pais_PaisId = c.Int(),
                    })
                .PrimaryKey(t => t.ProvinciaId)
                .ForeignKey("dbo.Pais", t => t.Pais_PaisId)
                .Index(t => t.Pais_PaisId);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        PaisId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.PaisId);
            
            CreateTable(
                "dbo.Nacionalidad",
                c => new
                    {
                        NacionalidadId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.NacionalidadId);
            
            CreateTable(
                "dbo.Sexo",
                c => new
                    {
                        SexoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.SexoId);
            
            CreateTable(
                "dbo.PreinscripcionOnline",
                c => new
                    {
                        PreinscripcionOnlineId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        Alumno_PersonaId = c.Long(),
                        Carrera_CarreraId = c.Int(),
                        Turno_TurnoId = c.Int(),
                    })
                .PrimaryKey(t => t.PreinscripcionOnlineId)
                .ForeignKey("dbo.Alumno", t => t.Alumno_PersonaId)
                .ForeignKey("dbo.Carrera", t => t.Carrera_CarreraId)
                .ForeignKey("dbo.Turno", t => t.Turno_TurnoId)
                .Index(t => t.Alumno_PersonaId)
                .Index(t => t.Carrera_CarreraId)
                .Index(t => t.Turno_TurnoId);
            
            CreateTable(
                "dbo.Turno",
                c => new
                    {
                        TurnoId = c.Int(nullable: false, identity: true),
                        FechaHora = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TurnoId);
            
            CreateTable(
                "dbo.Alumno",
                c => new
                    {
                        PersonaId = c.Long(nullable: false),
                        LugarDomicilio_LocalidadId = c.Int(),
                        LugarNacimiento_LocalidadId = c.Int(),
                        ProvinciaDomicilio_ProvinciaId = c.Int(),
                        ProvinciaNacimiento_ProvinciaId = c.Int(),
                        Legajo = c.Int(nullable: false),
                        AlumnoId = c.Int(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Celular = c.Int(nullable: false),
                        Mail = c.String(),
                        Domicilio = c.String(),
                        NomyApePMT = c.String(),
                        NombreColegio = c.String(),
                        TituloColegio = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        EstadoCivilId = c.Int(nullable: false),
                        NacionalidadId = c.Int(nullable: false),
                        SexoId = c.Int(nullable: false),
                        Localidad1Id = c.Int(nullable: false),
                        Localidad2Id = c.Int(nullable: false),
                        Provincia1Id = c.Int(nullable: false),
                        Provincia2Id = c.Int(nullable: false),
                        CarreraId = c.Int(nullable: false),
                        Emancipacion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonaId)
                .ForeignKey("dbo.Persona", t => t.PersonaId)
                .ForeignKey("dbo.Localidad", t => t.LugarDomicilio_LocalidadId)
                .ForeignKey("dbo.Localidad", t => t.LugarNacimiento_LocalidadId)
                .ForeignKey("dbo.Provincia", t => t.ProvinciaDomicilio_ProvinciaId)
                .ForeignKey("dbo.Provincia", t => t.ProvinciaNacimiento_ProvinciaId)
                .ForeignKey("dbo.EstadoCivil", t => t.EstadoCivilId, cascadeDelete: true)
                .ForeignKey("dbo.Nacionalidad", t => t.NacionalidadId, cascadeDelete: true)
                .ForeignKey("dbo.Sexo", t => t.SexoId, cascadeDelete: true)
                .ForeignKey("dbo.Carrera", t => t.CarreraId, cascadeDelete: true)
                .Index(t => t.PersonaId)
                .Index(t => t.LugarDomicilio_LocalidadId)
                .Index(t => t.LugarNacimiento_LocalidadId)
                .Index(t => t.ProvinciaDomicilio_ProvinciaId)
                .Index(t => t.ProvinciaNacimiento_ProvinciaId)
                .Index(t => t.EstadoCivilId)
                .Index(t => t.NacionalidadId)
                .Index(t => t.SexoId)
                .Index(t => t.CarreraId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alumno", "CarreraId", "dbo.Carrera");
            DropForeignKey("dbo.Alumno", "SexoId", "dbo.Sexo");
            DropForeignKey("dbo.Alumno", "NacionalidadId", "dbo.Nacionalidad");
            DropForeignKey("dbo.Alumno", "EstadoCivilId", "dbo.EstadoCivil");
            DropForeignKey("dbo.Alumno", "ProvinciaNacimiento_ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.Alumno", "ProvinciaDomicilio_ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.Alumno", "LugarNacimiento_LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Alumno", "LugarDomicilio_LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Alumno", "PersonaId", "dbo.Persona");
            DropForeignKey("dbo.PreinscripcionOnline", "Turno_TurnoId", "dbo.Turno");
            DropForeignKey("dbo.PreinscripcionOnline", "Carrera_CarreraId", "dbo.Carrera");
            DropForeignKey("dbo.PreinscripcionOnline", "Alumno_PersonaId", "dbo.Alumno");
            DropForeignKey("dbo.Persona", "TipoDocId", "dbo.TipoDoc");
            DropForeignKey("dbo.Localidad", "Provincia_ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.Provincia", "Pais_PaisId", "dbo.Pais");
            DropForeignKey("dbo.Administrativo", "TipoDoc_TipoDocId", "dbo.TipoDoc");
            DropIndex("dbo.Alumno", new[] { "CarreraId" });
            DropIndex("dbo.Alumno", new[] { "SexoId" });
            DropIndex("dbo.Alumno", new[] { "NacionalidadId" });
            DropIndex("dbo.Alumno", new[] { "EstadoCivilId" });
            DropIndex("dbo.Alumno", new[] { "ProvinciaNacimiento_ProvinciaId" });
            DropIndex("dbo.Alumno", new[] { "ProvinciaDomicilio_ProvinciaId" });
            DropIndex("dbo.Alumno", new[] { "LugarNacimiento_LocalidadId" });
            DropIndex("dbo.Alumno", new[] { "LugarDomicilio_LocalidadId" });
            DropIndex("dbo.Alumno", new[] { "PersonaId" });
            DropIndex("dbo.PreinscripcionOnline", new[] { "Turno_TurnoId" });
            DropIndex("dbo.PreinscripcionOnline", new[] { "Carrera_CarreraId" });
            DropIndex("dbo.PreinscripcionOnline", new[] { "Alumno_PersonaId" });
            DropIndex("dbo.Provincia", new[] { "Pais_PaisId" });
            DropIndex("dbo.Localidad", new[] { "Provincia_ProvinciaId" });
            DropIndex("dbo.Persona", new[] { "TipoDocId" });
            DropIndex("dbo.Administrativo", new[] { "TipoDoc_TipoDocId" });
            DropTable("dbo.Alumno");
            DropTable("dbo.Turno");
            DropTable("dbo.PreinscripcionOnline");
            DropTable("dbo.Sexo");
            DropTable("dbo.Nacionalidad");
            DropTable("dbo.Pais");
            DropTable("dbo.Provincia");
            DropTable("dbo.Localidad");
            DropTable("dbo.EstadoCivil");
            DropTable("dbo.Carrera");
            DropTable("dbo.Persona");
            DropTable("dbo.TipoDoc");
            DropTable("dbo.Administrativo");
        }
    }
}
