namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            //if obj is not null and type of obj is Product
            if (!(obj is null) && obj is Product)
            {
                Product productIn = (Product)obj;
                Product productThis = this;
                return productIn.Name == productThis.Name && productIn.Price == productThis.Price;
            }

            return false;
        }

        //public override bool Equals(object obj)
        //{
        //    if (obj is null) return false;
        //    if (!(obj is Product)) return false;
        //    var product = (Product)obj;
        //    return product.Name == this.Name && product.Price == this.Price;
        //}
    }
}
