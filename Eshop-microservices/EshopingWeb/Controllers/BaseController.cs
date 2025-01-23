using EshopingWeb.Utility;
using Microsoft.AspNetCore.Mvc;

namespace EshopingWeb.Controllers
{
    public class BaseController : Controller
    {
        protected readonly HttpClientHelper HttpClientHelper;
        public BaseController()
        {
            var httpClient = new HttpClient();
            HttpClientHelper = new HttpClientHelper(httpClient);
        }
        public void StoreToken(string token)
        {
            HttpContext?.Session.SetString("AuthToken", token);
        }

        public string GetToken()
        {
            return HttpContext?.Session.GetString("AuthToken")!;
        }
    }
}
