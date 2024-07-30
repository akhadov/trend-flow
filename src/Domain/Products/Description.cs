using SharedKernel;

namespace Domain.Products;
public sealed record Description
{
    public Description(string? value)
    {
        Ensure.NotNullOrEmpty(value);

        Value = value;
    }

    public string Value { get; }
}
