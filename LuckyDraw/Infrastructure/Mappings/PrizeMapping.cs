using AutoMapper;
using LuckyDraw.Domain;
using static LuckyDraw.Components.Pages.Main.Prize;

namespace LuckyDraw.Infrastructure.Mappings;

public class PrizeMapping : Profile
{
    public PrizeMapping()
    {
        CreateMap<Prize, PrizeModel>();
    }
}
