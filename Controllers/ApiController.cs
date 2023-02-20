using Data;
using IcelandApp.Extensions;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace IcelandApp.Controllers
{
    public class ApiController : Controller
    {

        [HttpPost]
        [Route("api/readPost")]
        public string ReadPost([FromServices] IProductService _productService)
        
        {
            var postString = Request.GetRawBodyStringAsync();
            var productList = _productService.CreateProductList(postString.Result);
            var updatedList = _productService.updateQuality(productList);
            var result = _productService.rebuildString(updatedList);
            return result;

        }
    }
}
