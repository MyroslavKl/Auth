using Lab2.Additional;
using Lab2.Models;
using Lab2.Repositories.Contracts;
using Lab2.Unit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lab2.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashService _hash;

        public UserController(IUnitOfWork unitOfWork,IHashService hash)
        {
            _unitOfWork = unitOfWork;
            _hash = hash;
        }
        
        [HttpGet("login")]
        public ActionResult Login() {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(string email, string password)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(email);
            if (user == null)
            {
                throw new Exception(message: "User Not Found");
            }
            var role = _unitOfWork.RoleRepository.GetAsync(user.RoleId);
            user.Role = role;
            var claims = new List<Claim>();
            claims.Add(new Claim("email", email));
            claims.Add(new Claim(ClaimTypes.Email, email));
            claims.Add(new Claim(ClaimTypes.Role, user.Role.RoleName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, email));
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);

            var isVerified = _hash.VerifyPassword(user.Password, password);
            if (!isVerified)
            {
                throw new Exception(message: "Not Valid Password");
            }

            TempData["ErrorInput"] = "Error. Incorrect gmail or password. Try again";
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet("register")]
        public ActionResult Register() {
            var data = _unitOfWork.RoleRepository.GetAll();
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user) {
            user.Password = _hash.HashPassword(user.Password);
            await _unitOfWork.UserRepository.InsertAsync(user);
            await _unitOfWork.Save();
            return RedirectToAction("Register");
        }
    }
}
