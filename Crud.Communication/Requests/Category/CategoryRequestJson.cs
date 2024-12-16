namespace Communication.Requests.Category;

public class CategoryRequestJson {
    public string Name{ get; set; }

    public CategoryRequestJson(string name){
        Name = name;
    }
}