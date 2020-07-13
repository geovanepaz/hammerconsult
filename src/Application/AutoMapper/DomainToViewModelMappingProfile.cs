using Application.ViewModels.Convidado;
using Application.ViewModels.Evento;
using Application.ViewModels.Funcionario;
using AutoMapper;
using Domain;
using Domain.DomainObjects;

namespace Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ParticipanteEvento, ParticipantesEventoResponse>();
            CreateMap<Funcionario, FuncionarioResponse>();
            CreateMap<Convidado, ConvidadoResponse>();
            CreateMap<EventoDetalhes, EventoDetalhesResponse>();
            CreateMap<Evento, EventoResponse>();
            CreateMap<Participante, ParticipanteResponse>();
        }
    }
}
