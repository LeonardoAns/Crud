namespace Communication.Response.Response;

public class ProductResponseJson {
    public long Id{ get; set; }
    public string Name{ get; set; }
    public string? Description{ get; set; }
    public decimal Value{ get; set; }

    public ProductResponseJson(long id, string name, string? description, decimal value){
        Id = id;
        Name = name;
        Description = description;
        Value = value;
    }
}