using LuckyDraw.Domain;

namespace LuckyDraw.Services;

public interface IWinnerService
{
    /// <summary>
    /// Retrieves all winners.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation, with a list of all winners as the result.</returns>
    Task<List<Winner>> GetAllWinnersAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of winners for a specific prize by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the prize to retrieve winners for.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation, with a list of winners for the specified prize.</returns>
    Task<List<Winner>> GetWinnersByPrizeIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Randomly selects a specified number of winners from the list of participants.
    /// </summary>
    /// <param name="quantity">The number of participants to select as winners.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of 
    /// <see cref="Participant"/> objects representing the randomly selected winners.
    /// If there are fewer participants than the specified quantity, an empty list is returned.
    /// </returns>
    Task<List<Participant>> GenerateRandomWinnersAsync(int quantity = 1, CancellationToken cancellationToken = default);

    /// <summary>
    /// Inserts a new winner.
    /// </summary>
    /// <param name="winner">The winner object to insert.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous insert operation.</returns>
    Task InsertWinnerAsync(Winner winner, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a winner.
    /// </summary>
    /// <param name="winner">The winner object to delete.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous delete operation.</returns>
    Task DeleteWinnerAsync(Winner winner, CancellationToken cancellationToken = default);
}
