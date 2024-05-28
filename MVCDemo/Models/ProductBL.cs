namespace MVCDemo.Models
{
    public class ProductBL
    {
        static List<Product> products;
        static ProductBL()
        {
            products = new List<Product>();
            products.Add(new Product() { Id = 1, Name = "car1", Description = "car1 is gold", Price = 50000, image = "1.png" });
            products.Add(new Product() { Id = 2, Name = "car2", Description = "car2 is gold", Price = 53000, image = "1.png" });
            products.Add(new Product() { Id = 3, Name = "car3", Description = "car3 is gold", Price = 50400, image = "1.png" });
            products.Add(new Product() { Id = 4, Name = "car4", Description = "car4 is gold", Price = 533000, image = "1.png" });
            products.Add(new Product() { Id = 5, Name = "car5", Description = "car5 is gold", Price = 5005600, image = "1.png" });
        }

        public static List<Product> getAll()
        {
            return products;
        }
    }
}
