using AutoMapper;
using Domain.DataTransferObjects;
using Domain.DbEntities;
using JetBrains.Annotations;

namespace Persistence.Mapping;

[UsedImplicitly]
public sealed class PatientMapping : Profile
{
    public PatientMapping()
    {
        CreateMap<Name, NameDto>()
            .ForMember(x => x.Id, u => u.MapFrom(x => x.Id))
            .ForMember(x => x.Use, u => u.MapFrom(x => x.Use))
            .ForMember(x => x.Family, u => u.MapFrom(x => x.Family))
            .ForMember(x => x.Given, u => u.MapFrom(x => x.Given));

        CreateMap<Patient, PatientDto>()
             .ForMember(x => x.Name, u => u.MapFrom(x => x.Name))
             .ForMember(x => x.Gender, u => u.MapFrom(x => x.Gender))
             .ForMember(x => x.DateOfBirth, u => u.MapFrom(x => x.DateOfBirth))
             .ForMember(x => x.Active, u => u.MapFrom(x => x.Active));
    }
}
