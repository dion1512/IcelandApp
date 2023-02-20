using Data;
using ServiceContracts;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>();

        }
        public List<Product> CreateProductList(string productLine)
        {
            using (StringReader reader = new StringReader(productLine))
            {
                List<Product> ListItem = new List<Product>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    Product item = new Product();
                    string[] words = Regex.Split(line, @"(-?\d+)");
                    foreach (var (value, index) in words.Where(c => !(c == null || c.Trim() == string.Empty)).Select((value, i) => (value, i)))
                    {

                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            if (index == 1)
                            {
                                item.SellIn = int.Parse(value);
                            }
                            else if (index == 2)
                            {
                                item.Quality = int.Parse(value);
                            }
                            else
                            {
                                item.Name = value.Trim();
                            }
                        }
                    }
                    ListItem.Add(item);
                }
                return ListItem;
            }

        }
        public List<Product> updateQuality(List<Product> productList)
        {
            var qualityMultiplier = 1;

            foreach(Product product in productList)
            {
                product.SellIn = product switch
                {
                    Product { Name: not "Soap" } p => p.SellIn = p.SellIn - 1,
                    _ => product.SellIn
                };
               
               
                if(product.SellIn >= 0)
                {
                    // handle in date products
                    product.Quality = product switch
                    {
                        Product { Quality: > 0 } and { Name: "Frozen Item" } p => p.Quality = p.Quality - qualityMultiplier,
                        Product { Quality: > 0 } and { Name: "Fresh Item" } p => p.Quality = p.Quality - (qualityMultiplier * 2),
                        Product { Name: "Christmas Crackers" } and { Quality: < 50 } and { SellIn: <= 10 and > 5 } p => p.Quality = p.Quality + (qualityMultiplier * 2),
                        Product { Name: "Christmas Crackers" } and { Quality: < 50 } and { SellIn: <= 5 } p => p.Quality = p.Quality + (qualityMultiplier * 3),
                        Product { Name: "Aged Brie" } and { Quality: < 50 } p => p.Quality = p.Quality + qualityMultiplier,
                        
                        _ => product.Quality
                    };
                }
                else
                {
                    // handle out of date products
                    product.Quality = product switch
                    {

                        Product { Quality: > 0 } and { Name: "Frozen Item" } p => p.Quality = p.Quality - (qualityMultiplier * 4),
                        Product { Quality: > 0 } and { Name: "Fresh Item" } p => p.Quality = p.Quality - (qualityMultiplier * 8),
                        Product { Name: "Christmas Crackers" } and { Quality: > 0 } p => p.Quality = 0,
                        Product { Name: not "Soap" } and { Quality: > 0 } p => p.Quality = p.Quality - (qualityMultiplier * 2),
                        _ => product.Quality
                    };
                }
                if (product.Quality > 50)
                {
                    product.Quality = 50;
                }

            }
            
            
            

            return productList;
        }
        public string rebuildString(List<Product> productList)
        {


            StringBuilder builder = new StringBuilder();
            foreach (Product product in productList)
            {

                builder.Append(product.Name).Append(" ").Append(product.SellIn).Append(" ").Append(product.Quality).Append("\n");
            }




            return builder.ToString();
        }

    }
}