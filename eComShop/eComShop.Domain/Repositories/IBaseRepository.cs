using System.Linq.Expressions;

namespace eComShop.Domain.Repositories
{
    /// <summary>
    /// Represents a generic repository for basic CRUD operations and more flexible data access.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity managed by the repository.</typeparam>
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Adds a new entity to the repository asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Adds a collection of entities to the repository asynchronously.
        /// </summary>
        /// <param name="entities">The collection of entities to be added.</param>
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Retrieves an entity by its unique identifier (e.g., primary key) asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the entity to retrieve.</param>
        /// <returns>The entity if found; otherwise, null.</returns>
        Task<TEntity> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves all entities of the specified type asynchronously.
        /// </summary>
        /// <returns>An enumerable collection of entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();        
       
        /// <summary>
        /// Retrieves entities that match the specified condition asynchronously.
        /// </summary>
        /// <param name="predicate">A condition expressed as a lambda expression.</param>
        /// <returns>An enumerable collection of entities that satisfy the condition.</returns>
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Updates an existing entity in the repository asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Updates a collection of entities in the repository asynchronously.
        /// </summary>
        /// <param name="entities">The collection of entities to be updated.</param>
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Deletes an entity from the repository asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Deletes a collection of entities from the repository asynchronously.
        /// </summary>
        /// <param name="entities">The collection of entities to be deleted.</param>
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Executes a query and returns a result (e.g., a projection) asynchronously.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="query">The query object that encapsulates the query logic.</param>
        /// <returns>The result of the query.</returns>
        // Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TEntity, TResult> query);

        /// <summary>
        /// Executes a command (e.g., for bulk updates, deletes, or custom operations) asynchronously.
        /// </summary>
        /// <param name="command">The command object that encapsulates the command logic.</param>
        // Task ExecuteCommandAsync(ICommand<TEntity> command);
    }
}
