namespace Preinscripcion.AccesoDatos.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Preinscripcion.Entidades;


    internal sealed class Configuration : DbMigrationsConfiguration<Preinscripcion.AccesoDatos.Context.PreinscripcionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Preinscripcion.AccesoDatos.Context.PreinscripcionContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var administrativos = new List<Administrativo>
            {
            new Administrativo {AdministrativoId=1,Usuario="camilamichelini",Contraseña="camila1234" },
            new Administrativo {AdministrativoId=2,Usuario="pauladelgiorgio",Contraseña="paula1234" },
            new Administrativo {AdministrativoId=3,Usuario="clarisaelosegui",Contraseña="clarisa1234" },
            new Administrativo {AdministrativoId=4,Usuario="rociogartxo",Contraseña="rocio1234" },
            };
            administrativos.ForEach(s => context.Administrativo.Add(s));
            context.SaveChanges();

            var carreras = new List<Carrera>
            {
             new Carrera{CarreraId=1,Nombre="Ingeniería Civil" },
             new Carrera{CarreraId=2,Nombre="Ingeniería Eléctrica" },
             new Carrera{CarreraId=3,Nombre="Ingeniería Industrial" },
             new Carrera{CarreraId=4,Nombre="Ingeniería Mecánica" },
             new Carrera{CarreraId=5,Nombre="Ingeniería en Sistemas de Información" },
             new Carrera{CarreraId=6,Nombre="Ingeniería Química" },
            };
            carreras.ForEach(s => context.Carrera.Add(s));
            context.SaveChanges();

            var estcivil = new List<EstadoCivil>
            {
             new EstadoCivil{EstadoCivilId=1,Descripcion="Soltero/a"},
             new EstadoCivil{EstadoCivilId=2,Descripcion="Casado/a"},
             new EstadoCivil{EstadoCivilId=3,Descripcion="Divorciado/a"},
             new EstadoCivil{EstadoCivilId=4,Descripcion="Viudo/a"},
             new EstadoCivil{EstadoCivilId=5,Descripcion="Concubino/a"},
            };
            estcivil.ForEach(s => context.EstadoCivil.Add(s));
            context.SaveChanges();

            var sexos = new List<Sexo>
            {
             new Sexo{SexoId=1,Descripcion="Masculino"},
             new Sexo{SexoId=2,Descripcion="Femenino"},
             new Sexo{SexoId=3,Descripcion="Otro"},
            };
            sexos.ForEach(s => context.Sexo.Add(s));
            context.SaveChanges();

            var tipoDocs = new List<TipoDoc>
            {
             new TipoDoc{TipoDocId=1,Descripcion="DNI" },
            };
            tipoDocs.ForEach(s => context.TipoDoc.Add(s));
            context.SaveChanges();


        }
    }
}
