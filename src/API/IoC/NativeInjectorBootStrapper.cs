using API.Configuration;
using Application.Interfaces;
using Application.Services;
using Application.ViewModels.Convidado;
using Application.ViewModels.Evento;
using Application.ViewModels.Login;
using Application.ViewModels.Funcionario;
using Application.ViewModels.Validations;
using Domain.Interfaces;
using FluentValidation;
using Infra.Contexts;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            //Validator 
            services.AddTransient<IValidator<LoginRequest>, LoginValidator>();
            services.AddTransient<IValidator<UsuarioRequest>, UsuarioValidator>();
            services.AddTransient<IValidator<FuncionarioRequest>, ParticipanteRequestValidator>();
            services.AddTransient<IValidator<ConvidadoRequest>, ConvidadoRequestValidator>();
            services.AddTransient<IValidator<EventoRequest>, EventoRequestValidator>();
            services.AddTransient<IValidator<ParticipanteEventoRequest>, ParticipantesEventoRequestValidator>();
            services.AddTransient<IValidator<CancelamentoRequest>, CancelamentoRequestValidator>();

            //Repository
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IConvidadoRepository, ConvidadoRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();

            //Appsercice
            services.AddScoped<IFuncionarioAppService, FuncionarioAppService>();
            services.AddScoped<IConvidadoAppService, ConvidadoAppService>();
            services.AddScoped<IEventoAppService, EventoAppService>();

            //Context
            services.AddScoped<ModeloContext>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddTransient<ISqlHelper, SqlHelper>();
        }
    }
}
