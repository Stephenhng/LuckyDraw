using AutoMapper;
using LuckyDraw.Domain;
using static LuckyDraw.Components.Pages.Main.Prize;

namespace LuckyDrawTest.Insfrastructure.Mapping;

public class PrizeMapping : Profile
{
    public PrizeMapping()
    {
        CreateMap<Prize, PrizeModel>();
    }
}
