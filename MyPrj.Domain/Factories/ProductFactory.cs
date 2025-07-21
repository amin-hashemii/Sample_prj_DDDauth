using MyPrj.Domain.Models;

namespace MyPrj.Domain.Factories;

public class ProductFactory
{
    public static product Create(string name, string description, string createdByUserId)
    {
        return new product(name, description, createdByUserId);
    }
}