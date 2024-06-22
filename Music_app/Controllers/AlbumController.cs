using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music_app.Models;
using Music_app.ViewModels;
using System;

namespace Music_app.Controllers
{
	public class AlbumController : Controller
    {

        private readonly MyMusicContext _context;

        public AlbumController(MyMusicContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
		{
            var albums = await _context.Albums
                                       .Include(a => a.Ctalbums)
                                       .ThenInclude(c => c.IdbaiHatNavigation)
                                       .Include(a => a.IdtacGiaNavigation)
                                       .ToListAsync();

            var albumVMs = albums.Select(a => new AlbumVM
            {
                Idalbum = a.Idalbum,
                TenAlbum = a.TenAlbum,
                NgayRaMat = a.NgayRaMat,
                LinkAnh = a.LinkAnh,
                IdtacGia = a.IdtacGia,
                TenTG = a.IdtacGiaNavigation?.TenTg,
                Ctalbums = a.Ctalbums.Select(ct => new Ctalbum
                {
                    Idctalbum = ct.Idctalbum,
                    Idalbum = ct.Idalbum,
                    IdbaiHat = ct.IdbaiHat,
                    IdalbumNavigation = ct.IdalbumNavigation,
                    IdbaiHatNavigation = ct.IdbaiHatNavigation
                }).ToList()
            }).ToList();

            var viewModel = new XemAlbumVM
            {
                AlbumVMs = albumVMs
            };

           
            return View(viewModel);
		}
        public async Task<IActionResult> Details(string id)
        {
            var album = await _context.Albums
                                      .Include(a => a.Ctalbums)
                                      .ThenInclude(ct => ct.IdbaiHatNavigation)
                                      .Include(a => a.IdtacGiaNavigation)
                                      .FirstOrDefaultAsync(a => a.Idalbum == id);
            if (album == null)
            {
                return NotFound();
            }

            var albumDetailVM = new AlbumDetailVM
            {
                Idalbum = album.Idalbum,
                TenAlbum = album.TenAlbum,
                NgayRaMat = album.NgayRaMat,
                LinkAnh = album.LinkAnh,
                IdtacGia = album.IdtacGia,
                TenTG = album.IdtacGiaNavigation?.TenTg,
                BaiHats = album.Ctalbums.Select(ct => new BaiHatVM
                {
                    IdbaiHat = ct.IdbaiHatNavigation?.IdbaiHat,
                    TenBaiHat = ct.IdbaiHatNavigation?.TenBaiHat,
                    LuotNghe = ct.IdbaiHatNavigation?.LuotNghe,
                    LinkNhac = ct.IdbaiHatNavigation?.LinkNhac,
                    LinkAnh = ct.IdbaiHatNavigation?.LinkAnh,
                    IdtacGia = ct.IdbaiHatNavigation?.IdtacGia,
                    TenTG = ct.IdbaiHatNavigation?.IdtacGiaNavigation?.TenTg
                }).ToList(),
                TacGia = album.IdtacGiaNavigation == null ? null : new TacGiaVM
                {
                    IdtacGia = album.IdtacGiaNavigation.IdtacGia,
                    TenTg = album.IdtacGiaNavigation.TenTg,
                    Ns = album.IdtacGiaNavigation.Ns,
                    QueQuan = album.IdtacGiaNavigation.QueQuan,
                    TieuSu = album.IdtacGiaNavigation.TieuSu,
                    GioiTinh = album.IdtacGiaNavigation.GioiTinh,
                    LinkAnh = album.IdtacGiaNavigation.LinkAnh
                }
            };

            return View(albumDetailVM);
        }
    }
}
