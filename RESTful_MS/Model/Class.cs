namespace RESTful_MS.Model
{

    public abstract class Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }
    public class Product : Base
    {
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public  int BrandId { get; set; }
        public Brand? Brand { get; set; }
    }

    public class Category : Base 
    {
        public ICollection<Product> Products { get; set; } = [];
    }
    public class  Brand: Base 
    {
        public ICollection<Product> Products { get; set; } = [];
    }

    public class Cart 
    {
        public int Id { get; set; }
        public string Status { get; set; } = "Pending";
        public ICollection<CartItem> Items { get; set; } = [];

    }

    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal ProductId { get; set; }
        public Product Product { get; set; } 
        public int CartId { get; set; }
        public Cart Cart { get; set; } 
    }

    public class Receipt
    {
        public int Id { get; set; }
        public DateTime PurchaseData { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public ICollection<ReceiptItem> Items { get; set; } = [];
    }

    public class ReceiptItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }
        public Product? Product { get; set; }
        public int ProductId { get; set; }
        public int ReceiptId { get; set; }
        public Receipt? Receipt { get; set; }
    }
}
