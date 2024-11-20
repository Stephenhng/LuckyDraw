using AutoMapper;
using LuckyDraw.Domain;
using static LuckyDraw.Components.Pages.Main.Participant;

namespace LuckyDraw.Infrastructure.Mappings;

public class ParticipantMapping : Profile
{
    public ParticipantMapping()
    {
        CreateMap<Participant, ParticipantModel>()
            .ForMember(dest => dest.IdentityNumder, opt => opt.MapFrom(src => src.IdentityNumber));
    }
}
