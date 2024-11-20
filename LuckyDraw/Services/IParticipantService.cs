using LuckyDraw.Domain;

namespace LuckyDraw.Services;

public interface IParticipantService
{
    /// <summary>
    /// Retrieves all participants.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation, with a list of all participants as the result.</returns>
    Task<List<Participant>> GetAllParticipantsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a participant by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the participant.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation, with the participant object as the result, or null if no participant is found with the given ID.</returns>
    Task<Participant?> GetParticipantByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Inserts a new participant.
    /// </summary>
    /// <param name="participant">The participant object to insert.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous insert operation.</returns>
    Task InsertParticipantAsync(Participant participant, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing participant's information.
    /// </summary>
    /// <param name="participant">The participant object containing the updated information.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous update operation.</returns>
    Task UpdateParticipantAsync(Participant participant, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a participant.
    /// </summary>
    /// <param name="participant">The participant object to delete.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous delete operation.</returns>
    Task DeleteParticipantAsync(Participant participant, CancellationToken cancellationToken = default);
}
