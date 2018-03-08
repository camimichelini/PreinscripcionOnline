namespace Preinscripcion.AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alumno", "LugarDomicilio_LocalidadId", c => c.Int());
            AddColumn("dbo.Alumno", "LugarNacimiento_LocalidadId", c => c.Int());
            AddColumn("dbo.Alumno", "ProvinciaDomicilio_ProvinciaId", c => c.Int());
            AddColumn("dbo.Alumno", "ProvinciaNacimiento_ProvinciaId", c => c.Int());
            AddColumn("dbo.Alumno", "FotoDoc", c => c.Binary());
            AddColumn("dbo.Alumno", "Analitico", c => c.Binary());
            AddColumn("dbo.Alumno", "CertificadoTrabajo", c => c.Binary());
            CreateIndex("dbo.Alumno", "LugarDomicilio_LocalidadId");
            CreateIndex("dbo.Alumno", "LugarNacimiento_LocalidadId");
            CreateIndex("dbo.Alumno", "ProvinciaDomicilio_ProvinciaId");
            CreateIndex("dbo.Alumno", "ProvinciaNacimiento_ProvinciaId");
            AddForeignKey("dbo.Alumno", "LugarDomicilio_LocalidadId", "dbo.Localidad", "LocalidadId");
            AddForeignKey("dbo.Alumno", "LugarNacimiento_LocalidadId", "dbo.Localidad", "LocalidadId");
            AddForeignKey("dbo.Alumno", "ProvinciaDomicilio_ProvinciaId", "dbo.Provincia", "ProvinciaId");
            AddForeignKey("dbo.Alumno", "ProvinciaNacimiento_ProvinciaId", "dbo.Provincia", "ProvinciaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alumno", "ProvinciaNacimiento_ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.Alumno", "ProvinciaDomicilio_ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.Alumno", "LugarNacimiento_LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Alumno", "LugarDomicilio_LocalidadId", "dbo.Localidad");
            DropIndex("dbo.Alumno", new[] { "ProvinciaNacimiento_ProvinciaId" });
            DropIndex("dbo.Alumno", new[] { "ProvinciaDomicilio_ProvinciaId" });
            DropIndex("dbo.Alumno", new[] { "LugarNacimiento_LocalidadId" });
            DropIndex("dbo.Alumno", new[] { "LugarDomicilio_LocalidadId" });
            DropColumn("dbo.Alumno", "CertificadoTrabajo");
            DropColumn("dbo.Alumno", "Analitico");
            DropColumn("dbo.Alumno", "FotoDoc");
            DropColumn("dbo.Alumno", "ProvinciaNacimiento_ProvinciaId");
            DropColumn("dbo.Alumno", "ProvinciaDomicilio_ProvinciaId");
            DropColumn("dbo.Alumno", "LugarNacimiento_LocalidadId");
            DropColumn("dbo.Alumno", "LugarDomicilio_LocalidadId");
        }
    }
}
