using LuckyDraw.Domain;

namespace LuckyDraw.Services;

public interface IPrizeService
{
    /// <summary>
    /// Retrieves all prizes.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation, with a list of all prizes as the result.</returns>
    Task<List<Prize>> GetAllPrizesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a prize by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the prize.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation, with the prize object as the result, or null if no prize is found with the given ID.</returns>
    Task<Prize?> GetPrizeByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Inserts a new prize.
    /// </summary>
    /// <param name="prize">The prize object to insert.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous insert operation.</returns>
    Task InsertPrizeAsync(Prize prize, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing prize's information.
    /// </summary>
    /// <param name="prize">The prize object containing the updated information.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous update operation.</returns>
    Task UpdatePrizeAsync(Prize prize, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a prize.
    /// </summary>
    /// <param name="prize">The prize object to delete.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous delete operation.</returns>
    Task DeletePrizeAsync(Prize prize, CancellationToken cancellationToken = default);
}
