namespace Commerce.Domain.Contracts;

public interface ICategoryRepository
{
    Task AddAsync(Category category, CancellationToken token);
    Task<Category?> FindByNameAsync(string name, CancellationToken token);
}
