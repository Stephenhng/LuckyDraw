using LuckyDraw.Data;
using LuckyDraw.Domain;
using Microsoft.EntityFrameworkCore;

namespace LuckyDraw.Services;

public class ParticipantService(ApplicationDbContext applicationDbContext) : IParticipantService
{
    public async Task<List<Participant>> GetAllParticipantsAsync(CancellationToken cancellationToken = default)
    {
        return await applicationDbContext.Participants.AsNoTracking().AsQueryable().ToListAsync(cancellationToken);
    }

    public async Task<Participant?> GetParticipantByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await applicationDbContext.Participants.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task InsertParticipantAsync(Participant participant, CancellationToken cancellationToken = default)
    {
        applicationDbContext.Add(participant);
        await applicationDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateParticipantAsync(Participant participant, CancellationToken cancellationToken = default)
    {
        applicationDbContext.Update(participant);
        await applicationDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteParticipantAsync(Participant participant, CancellationToken cancellationToken = default)
    {
        applicationDbContext.Remove(participant);
        await applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}
