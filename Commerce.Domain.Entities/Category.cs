namespace Commerce.Domain.Entities;

public  class Category
{
    public Category(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public long Id { get; set; }
    public string Name { get; set; }
}
