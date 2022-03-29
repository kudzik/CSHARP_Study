﻿namespace ClassLibrary.Entity
{
    public class Purchase
    {
        public int ID { get; set; }
        public int? CustomerID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public  Customer Customer { get; set; }
    }
}