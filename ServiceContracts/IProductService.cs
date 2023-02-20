using Data;

namespace ServiceContracts
{
    public interface IProductService
    {
        List<Product> CreateProductList(string postStringx);
        List<Product> updateQuality(List<Product> products);
        string rebuildString(List<Product> products);
    }
}