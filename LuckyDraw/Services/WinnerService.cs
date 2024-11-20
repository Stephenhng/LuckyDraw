using LuckyDraw.Data;
using LuckyDraw.Domain;
using Microsoft.EntityFrameworkCore;

namespace LuckyDraw.Services;

public class WinnerService(ApplicationDbContext applicationDbContext) : IWinnerService
{
    public async Task<List<Winner>> GetAllWinnersAsync(CancellationToken cancellationToken = default)
    {
        return await applicationDbContext.Winners.AsNoTracking().AsQueryable().ToListAsync(cancellationToken);
    }

    public async Task<List<Winner>> GetWinnersByPrizeIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await applicationDbContext.Winners.Where(p => p.PrizeId == id).ToListAsync(cancellationToken);
    }

    public async Task<List<Participant>> GenerateRandomWinnersAsync(int quantity = 1, CancellationToken cancellationToken = default)
    {
        if (await applicationDbContext.Participants.CountAsync(cancellationToken) < quantity)
            return [];

        return await applicationDbContext.Participants
            .OrderBy(r => Guid.NewGuid())
            .Take(quantity)
            .ToListAsync(cancellationToken);
    }

    public async Task InsertWinnerAsync(Winner winner, CancellationToken cancellationToken = default)
    {
        applicationDbContext.Add(winner);
        await applicationDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteWinnerAsync(Winner winner, CancellationToken cancellationToken = default)
    {
        applicationDbContext.Remove(winner);
        await applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}
