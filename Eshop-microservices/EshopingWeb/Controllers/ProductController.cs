using EshopingWeb.Models;
using EshopingWeb.Utility;
using Microsoft.AspNetCore.Mvc;

namespace EshopingWeb.Controllers
{
    public class ProductController : BaseController
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> ProductList()
        {
            var token = GetToken();

            if (string.IsNullOrEmpty(token))
                return Json(new { success = false, message = "User is not authenticated." });
            var headers = new Dictionary<string, string>
                {
                    { "Authorization", $"Bearer {token}" }
                };
            var data = await HttpClientHelper.GetAsync<ProductResponse>(CommanAPIUrl.GetProductList , headers);
            if (data == null)
            {
                return Json(new { success = false, message = "Data not found." });
            }
            return Json(new { success = true, data });
        }
    }
}
