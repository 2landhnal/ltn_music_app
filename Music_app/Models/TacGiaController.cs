using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music_app.ViewModels;

namespace Music_app.Models
{
	public class TacGiaController : Controller
	{
		private readonly MyMusicContext _context;


		public TacGiaController(MyMusicContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult DanhSachBaiHat(string id)
		{
			var artist = _context.TacGia.SingleOrDefault(t => t.IdtacGia == id);
			if (artist == null)
			{
				return NotFound();
			}

			var songs = _context.BaiHats
				.Where(b => b.IdtacGia == id)
				.Select(s => new BaiHatVM
				{
					IdbaiHat = s.IdbaiHat,
					TenBaiHat = s.TenBaiHat,
					LinkNhac = s.LinkNhac,
					LinkAnh = s.LinkAnh,
					LuotNghe = s.LuotNghe ?? 0
				}).ToList();

			var viewModel = new TacGiaVM
			{
				IdtacGia = artist.IdtacGia,
				TenTg = artist.TenTg,
				LinkAnh = artist.LinkAnh,
				BaiHats = songs
			};

			return View(viewModel);
		}
	}
	
}
