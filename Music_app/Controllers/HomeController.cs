using Microsoft.AspNetCore.Mvc;
using Music_app.Models;
using Music_app.ViewModels;
using System.Diagnostics;

namespace Music_app.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly MyMusicContext db;

      
        public HomeController(MyMusicContext context) {
            db = context;
        }



        public IActionResult Index(string? tacgia)
        {
            var baihats = db.BaiHats.AsQueryable();
            var tacgias = db.TacGia.AsQueryable();
            if (tacgia != null)
            {
                baihats = baihats.Where(p => p.IdtacGia == tacgia);
            }
            var baiHat = baihats.Select(p => new BaiHatVM
            {
                IdbaiHat = p.IdbaiHat,
                TenBaiHat = p.TenBaiHat,
                IdtacGia = p.IdtacGia,
                LinkAnh = p.LinkAnh,
                LinkNhac = p.LinkNhac,
                TenTG = p.IdtacGiaNavigation.TenTg,

            }).Take(5);
            var tacGia = tacgias.Select(p => new TacGiaVM
            {
                IdtacGia = p.IdtacGia,
				LinkAnh = p.LinkAnh,
                TenTg = p.TenTg,
            });

            var albums = db.Albums.Select(p => new AlbumVM
            {
                Idalbum = p.Idalbum,
                TenAlbum = p.TenAlbum,
                LinkAnh =   p.LinkAnh,
                IdtacGia = p.IdtacGia,
                TenTG = p.IdtacGiaNavigation.TenTg,
            });
            var result = new HomeVM
            {
                BaiHatVMs = baiHat,
                TacGiaVMs = tacGia,
                AlbumVMs = albums,
                
            };
            return View(result);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
