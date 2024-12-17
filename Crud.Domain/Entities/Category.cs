namespace Crud.Domain.Entities;
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        public long UserId { get; set; }

        public User User { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public Category() { }

        public Category(string name)
        {
            Name = name;
        }
    }
