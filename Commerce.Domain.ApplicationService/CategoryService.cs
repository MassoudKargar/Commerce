namespace Commerce.Domain.ApplicationService;

public class CategoryService  
{
    public CategoryService(ICategoryRepository category)
    {
        Category = category ?? throw new ArgumentNullException(nameof(category));
    }

    private ICategoryRepository Category { get; }

    public async Task AddCategoryAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            await Task.FromException(new ArgumentNullException(nameof(name)));
        }
        CancellationTokenSource tokenSource = new(new TimeSpan(0, 1, 0));
        var categoryInDb = await Category.FindByNameAsync(name, tokenSource.Token);
        if (categoryInDb is not null)
        {
            tokenSource.Dispose();
            await Task.FromException(new DuplicateWaitObjectException(nameof(name)));
        }
        var category = new Category(name);
        await Category.AddAsync(category, tokenSource.Token);
        tokenSource.Dispose();
        await Task.CompletedTask;
    }
}