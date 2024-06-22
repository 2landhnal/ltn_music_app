using Microsoft.AspNetCore.Mvc;
using Music_app.Models;
using Music_app.ViewModels;
using Music_app.Helpers;

namespace Music_app.Controllers
{
    public class DangKyController : Controller
    {
		private MyMusicContext db;

		public DangKyController(MyMusicContext contex) 
        { 
            db = contex;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra nếu tên người dùng đã tồn tại
                var existingUser = db.TaiKhoans.SingleOrDefault(u => u.TenTk == model.UserName);
                if (existingUser != null)
                {
                    ModelState.AddModelError("UserName", "Username already exists.");
                    return View(model);
                }

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // Tạo người dùng mới
                        var newUser = new User
                        {
                            Iduser = Hash.GenerateShortGuid(),
                            TenUser = model.FullName,
                            GioiTinh = model.Gender,
                            QuocTich = model.Nationality,
                            NgaySinh = DateOnly.FromDateTime(model.DateOfBirth),
                            Sdt = model.Sdt,
                        };
                        db.Users.Add(newUser);
                        db.SaveChanges();

                        // Tạo tài khoản mới
                        var newTaiKhoan = new TaiKhoan
                        {
                            TenTk = model.UserName,
                            MatKhau = model.Password, // Lưu ý: Mật khẩu nên được băm trước khi lưu
                            Iduser = newUser.Iduser
                        };
                        db.TaiKhoans.Add(newTaiKhoan);
                        db.SaveChanges();

                        transaction.Commit();

                        // Chuyển hướng đến trang thành công hoặc trang đăng nhập
                        return RedirectToAction("Index","DangNhap");
                    }
                    catch
                    {
                        transaction.Rollback();
                        ModelState.AddModelError("", "An error occurred while creating the account. Please try again.");
                    }
                }
            }

            // Nếu có lỗi xác thực, trả về view với model hiện tại
            return View(model);
        }
    }
}
