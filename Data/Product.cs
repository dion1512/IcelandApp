using System.ComponentModel.DataAnnotations;

namespace Data
{

    public class Product
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        [Range(0, 50, ErrorMessage = "Quality must be between {1} and {2}.")]
        public int Quality { get; set; }
    }

}