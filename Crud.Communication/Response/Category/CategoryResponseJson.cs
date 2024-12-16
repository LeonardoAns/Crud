namespace Communication.Response.Category;

public class CategoryResponseJson {

    public long Id{ get; set; }
    public string Name{ get; set; }

    public CategoryResponseJson(long id, string name){
        Id = id;
        Name = name;
    }
}