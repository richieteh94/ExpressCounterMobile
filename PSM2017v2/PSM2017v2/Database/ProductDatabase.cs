using PSM2017v2.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSM2017v2.Database
{
    public class ProductDatabase
    {
        private SQLiteConnection db;
        public ProductDatabase(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Product>();
        }

        public void AddProduct(Product product)
        {
            db.Insert(product);
        }
        public void UpdateProduct(Product product)
        {
            db.Update(product);
        }
        public void DeleteProduct(Product product)
        {
            db.Delete(product);
        }
        public void ClearList()
        {
            db.DeleteAll<Product>();
        }
        public List<Product> GetProducts()
        {
            return db.Table<Product>().ToList();
        }

        public Product GetProduct(int id)
        {
            return db.Table<Product>().Where(i => i.ID == id).First();
        }
    }
}
