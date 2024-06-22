using Microsoft.AspNetCore.Mvc;
using Music_app.Models;
using Music_app.ViewModels;

namespace Music_app.Controllers
{
    public class XemHistoryController : Controller
    {
        private readonly MyMusicContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public XemHistoryController(MyMusicContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "DangNhap");
            }

            var history = _context.LichSus
                .Where(ls => ls.Iduser == userId)
                .OrderByDescending(ls => ls.Thoigian)
                .Select(ls => new ListeningHistoryViewModel
                {
                    SongName = ls.IdbaiHatNavigation.TenBaiHat,
                    IdbaiHat = ls.IdbaiHat,
                    ArtistName = ls.IdbaiHatNavigation.IdtacGiaNavigation.TenTg,
                    ImageUrl = ls.IdbaiHatNavigation.LinkAnh,
                    ListeningTime = ls.Thoigian.Value,
                    LinkNhac = ls.IdbaiHatNavigation.LinkNhac
                })
                .ToList().Take(10);

            return View(history);
        }
    }
}
