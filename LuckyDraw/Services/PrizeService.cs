using LuckyDraw.Data;
using LuckyDraw.Domain;
using Microsoft.EntityFrameworkCore;

namespace LuckyDraw.Services;

public class PrizeService(ApplicationDbContext applicationDbContext) : IPrizeService
{
    public async Task<List<Prize>> GetAllPrizesAsync(CancellationToken cancellationToken = default)
    {
        return await applicationDbContext.Prizes.AsNoTracking().AsQueryable().ToListAsync(cancellationToken);
    }

    public async Task<Prize?> GetPrizeByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await applicationDbContext.Prizes.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task InsertPrizeAsync(Prize prize, CancellationToken cancellationToken = default)
    {
        applicationDbContext.Add(prize);
        await applicationDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdatePrizeAsync(Prize prize, CancellationToken cancellationToken = default)
    {
        applicationDbContext.Update(prize);
        await applicationDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeletePrizeAsync(Prize prize, CancellationToken cancellationToken = default)
    {
        applicationDbContext.Remove(prize);
        await applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}
