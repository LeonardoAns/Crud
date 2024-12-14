namespace Crud.Domain.Entities;

public class Product {
    public long Id{ get; set; }
    public string Name{ get; set; }
    public string? Description{ get; set; }
    public decimal Value{ get; set; }
    public long CategoryId{ get; set; }
    public Category Category{ get; set; }

}