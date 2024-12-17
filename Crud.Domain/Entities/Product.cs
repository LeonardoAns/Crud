namespace Crud.Domain.Entities;
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }

        public long CategoryId { get; set; }

        public Category Category { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public Product() { }

        public Product(string name, string? description, decimal value, long categoryId, Category category)
        {
            Name = name;
            Description = description;
            Value = value;
            CategoryId = categoryId;
            Category = category;
        }
    }
