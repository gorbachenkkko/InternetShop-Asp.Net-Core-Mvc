using InternetShop.Domain.Enum;

namespace InternetShop.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Role Role { get; set; }
        public string? Password { get; set; }
        //public Basket Basket { get; set; }
    }
}
