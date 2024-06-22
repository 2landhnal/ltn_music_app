using Microsoft.AspNetCore.Mvc;
using Music_app.Models;
using Music_app.ViewModels;
namespace Music_app.ViewComponents
{
    public class BaiHatViewComponent : ViewComponent
    {
        private readonly MyMusicContext db;

        public BaiHatViewComponent(MyMusicContext context) => db = context;
        public IViewComponentResult Invoke()
        {
            var data = db.BaiHats.Select(bh => new BaiHatVM
            { IdbaiHat = bh.IdbaiHat,
                TenBaiHat = bh.TenBaiHat,
                LuotNghe = bh.LuotNghe

            });

            return View(data);
        }
    }
}
