namespace Communication.Requests.Product;

public class ProductRequestJson {
    public string Name{ get; set; }
    public string? Description{ get; set; }
    public decimal Value{ get; set; }
    
    public long CategoryId{ get; set; }


    public ProductRequestJson(string name, string? description, decimal value, long categoryId){
        Name = name;
        Description = description;
        Value = value;
        CategoryId = categoryId;
    }
}