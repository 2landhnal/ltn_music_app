using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music_app.Models;
using Music_app.ViewModels;

namespace Music_app.Controllers
{
	public class DsphatController : Controller
	{
		private readonly MyMusicContext _context;

		public DsphatController(MyMusicContext context)
		{
			_context = context;
		}

		// Action để xem danh sách phát
		public async Task<IActionResult> Index()
		{
			var userId = HttpContext.Session.GetString("UserId");
			if (userId == null)
			{
				// Chuyển hướng đến trang đăng nhập nếu chưa đăng nhập
				return RedirectToAction("Index", "DangNhap");
			}

			var playlists = await _context.Dsphats
				.Include(p => p.Ctdsphats)
				.ThenInclude(c => c.IdbaiHatNavigation)
				.Where(p => p.Iduser == userId)
				.Select(p => new DsphatVM
				{
					Iddsphat = p.Iddsphat,
					TenDsphat = p.TenDsphat,
					ThoiGian = p.ThoiGian,
					Iduser = p.Iduser,
					BaiHats = p.Ctdsphats.Select(c => new BaiHatVM
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

			return View(playlists);
		}
	}
}
