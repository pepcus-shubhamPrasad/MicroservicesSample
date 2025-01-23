using System.Text.Json;
using EshopingWeb.Models;
using EshopingWeb.Utility;
using Microsoft.AspNetCore.Mvc;

namespace EshopingWeb.Controllers
{
    public class AuthController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }
        public async Task<IActionResult> UserList()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetUserList()
        {
            var token = GetToken();
            if (string.IsNullOrEmpty(token))
                return Json(new { success = false, message = "User is not authenticated." });
            var headers = new Dictionary<string, string>
                {
                    { "Authorization", $"Bearer {token}" }
                };
            var data = await HttpClientHelper.GetAsync<List<UserList>>(CommanAPIUrl.GetUserList, headers);
            if (data == null)
            {
                return Json(new { success = false, message = "Data not found." });
            }
            return Json(new { success = true, data });
        }

        [HttpPost]
        public async Task<JsonResult> CreateUser([FromBody] UserModel user)
        {
            var data = await HttpClientHelper.PostAsync<UserResponse>(CommanAPIUrl.CreatLoginUser, user);
            if (ModelState.IsValid)
            {
                return Json(new { success = true, message = "User added successfully." });
            }
            else
            {
                return Json(new { success = false, message = "Invalid user data." });
            }
        }
        [HttpGet]
        public async Task<IActionResult> AuthLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> AuthLogin([FromForm] string Username)
        {
            var Model = new UserLogin() { Username = Username };
            var data = await HttpClientHelper.PostAsync<AuthResponse>(CommanAPIUrl.LoginUser, Model);
            if (data != null && data.Success && ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(data.Token))
                {
                    // Store the token in the session
                    StoreToken(data.Token);

                    return Json(new { success = true, message = "User logged in successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Token is null or empty." });
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid user data." });
            }
        }
    }
}
