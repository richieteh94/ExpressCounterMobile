using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSM2017v2.Model
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string barcode { get; set; }

    }
}
