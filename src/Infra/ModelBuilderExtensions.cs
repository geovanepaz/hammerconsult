using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infra
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Funcionario 
            var geovane = new Funcionario("Geovane Paz", "geovane@gmail.com", "Dev .Net", "TI");
            var jonas = new Funcionario("Jonas", "jonas@gmail.com", "Dev .Net", "TI");
            var rodrigo = new Funcionario("Rodrigo", "rodrigo@gmail.com", "Dev .Net", "TI");
            var roger = new Funcionario("Roger", "roger@gmail.com", "Dev .Net", "TI");

            modelBuilder.Entity<Funcionario>().HasData(geovane, jonas, rodrigo, roger);

            //convidado 
            var deise = new Convidado(geovane.Id, "Deise - Irmã Geovane", "deise@gmail.com");
            var maria = new Convidado(jonas.Id, "Maria - Namorada Jonas", "maria@gmail.com");

            modelBuilder.Entity<Convidado>().HasData(maria, deise);

            //Evento 
            var chursas = new Evento("Churras ano que vem", DateTime.Now.AddDays(365), 100, 100);

            modelBuilder.Entity<Evento>().HasData(chursas);

            //ParicipanteEvento  
            var participante1 = new ParticipanteEvento(chursas.Id, geovane.Id, deise.Id, 20, 20, true, true);
            var participante2 = new ParticipanteEvento(chursas.Id, jonas.Id, maria.Id, 20, 0, false, false);
            var participante3 = new ParticipanteEvento(chursas.Id, rodrigo.Id, null, 10, 10, false, true);

            modelBuilder.Entity<ParticipanteEvento>().HasData(participante1, participante2, participante3);
        }
    }
}
