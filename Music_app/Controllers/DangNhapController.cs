using Microsoft.AspNetCore.Mvc;
using Music_app.Models;
using Music_app.ViewModels;
using System.Linq;
namespace Music_app.Controllers
{
    public class DangNhapController : Controller
    {
        private readonly MyMusicContext _context;

        public DangNhapController(MyMusicContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                // Tìm người dùng trong cơ sở dữ liệu dựa trên tên người dùng và mật khẩu
                var user = _context.TaiKhoans.FirstOrDefault(u => u.TenTk == model.Username && u.MatKhau == model.Password);

                if (user != null)
                {
					// Đăng nhập thành công, lưu ID người dùng vào session
					HttpContext.Session.SetString("UserId", user.Iduser);
					// Đăng nhập thành công, chuyển hướng đến trang chính
					return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Hiển thị thông báo lỗi nếu tên người dùng hoặc mật khẩu không đúng
                    ModelState.AddModelError("", "Tên người dùng hoặc mật khẩu không chính xác.");
                }
            }

            // Nếu xác thực thất bại, hiển thị lại form đăng nhập với thông báo lỗi
            return View(model);
        }
    }
}
