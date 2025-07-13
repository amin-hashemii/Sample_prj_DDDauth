namespace MyPrj.Domain.Models;

public class product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CreatedByUserId { get; set; }
}