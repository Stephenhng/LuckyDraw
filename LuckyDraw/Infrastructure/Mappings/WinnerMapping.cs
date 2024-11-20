using AutoMapper;
using LuckyDraw.Domain;
using static LuckyDraw.Components.Pages.Main.Winner;

namespace LuckyDraw.Infrastructure.Mappings;

public class WinnerMapping : Profile
{
    public WinnerMapping()
    {
        CreateMap<Winner, WinnerModel>()
            .ForMember(dest => dest.ParticipantName, opt => opt.MapFrom(src => src.Participant!.Name))
            .ForMember(dest => dest.PrizeName, opt => opt.MapFrom(src => src.Prize!.Name));
    }
}
