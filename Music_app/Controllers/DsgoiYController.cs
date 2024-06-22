using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music_app.Models;
using Music_app.ViewModels;

namespace Music_app.Controllers
{
    public class DsgoiYController : Controller
    {
        private readonly MyMusicContext _context;

        public DsgoiYController(MyMusicContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId == null)
            {
                // Chuyển hướng đến trang đăng nhập nếu chưa đăng nhập
                return RedirectToAction("Index", "DangNhap");
            }

            var dsgoiYs = await _context.DsgoiYs
                .Include(d => d.CtdsdgoiYs)
                .ThenInclude(c => c.IdbaiHatNavigation)
                .Where(d => d.Iduser == userId)
                .Select(d => new DsgoiYVM
                {
                    IddsgoiY = d.IddsgoiY,
                    TenDsgoiY = d.TenDsgoiY,
                    Iduser = d.Iduser,
                    BaiHats = d.CtdsdgoiYs.Select(c => new BaiHatVM
                    {
                        IdbaiHat = c.IdbaiHatNavigation.IdbaiHat,
                        TenBaiHat = c.IdbaiHatNavigation.TenBaiHat,
                        LuotNghe = c.IdbaiHatNavigation.LuotNghe,
                        LinkNhac = c.IdbaiHatNavigation.LinkNhac,
                        LinkAnh = c.IdbaiHatNavigation.LinkAnh,
                        IdtacGia = c.IdbaiHatNavigation.IdtacGia,
                        TenTG = c.IdbaiHatNavigation.IdtacGiaNavigation.TenTg
                    }).ToList()
                }).ToListAsync();

            return View(dsgoiYs);
        }
    }
}
