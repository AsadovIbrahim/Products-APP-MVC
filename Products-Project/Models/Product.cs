namespace Products_Project.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }
        public string ?Description { get; set; }

        public Product(string name,float price,string description)
        {
            Name = name; 
            Price = price;
            Description = description;
        }
        public Product()
        {
        }
        public override string ToString()
        {
            return $"Id:{Id}\nName:{Name}\nPrice:{Price}\nDescription:{Description}";
        }
    }
}
