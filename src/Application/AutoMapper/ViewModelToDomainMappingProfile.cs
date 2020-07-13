
using AutoMapper;
using Domain;
using System;

namespace Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //CreateMap<ParticipanteRequest, Cidade>()
            // .ConstructUsing(c => new Cidade(c.Nome, c.Codigo, c.UF));
        }
    }
}
