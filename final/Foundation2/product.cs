namespace OnlineOrdering
{
    class Product
    {
        private string name;
        private int productId;
        private decimal price;
        private int quantity;

        public Product(string name, int productId, decimal price, int quantity)
        {
            this.name = name;
            this.productId = productId;
            this.price = price;
            this.quantity = quantity;
        }

        public decimal CalculateTotalPrice()
        {
            return price * quantity;
        }

        public string Name
        {
            get { return name; }
        }

        public int ProductId
        {
            get { return productId; }
        }
    }
}
