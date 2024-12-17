using Crud.Domain.Entities;
using Crud.Domain.Enums;

namespace Crud.Domain.Entities;
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid Identifier { get; set; }
        public string Role{ get; set; } = Roles.ADMIN;

        public ICollection<Category> Categories { get; set; } = new List<Category>();

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public User() { }

        public User( string name, string email, string password){
            Name = name;
            Email = email;
            Password = password;
        }
    }
