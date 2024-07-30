using SharedKernel;

namespace Domain.Products;
public sealed class Product : Entity
{
    private Product(Guid id, Name name, Description description, string imagePath)
        : base(id)
    {
        Name = name;
        Description = description;
        ImagePath = imagePath;
    }

    private Product() { }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public string ImagePath { get; private set; }

    public static Product Create(Name name, Description description, string imagePath)
    {
        var product = new Product(Guid.NewGuid(), name, description, imagePath);

        product.Raise(new ProductCreatedDomainEvent(product.Id));

        return product;
    }
}
