namespace ClassLibrary.Entity
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public  List<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}