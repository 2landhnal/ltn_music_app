using Music_app.Models;

namespace Music_app.ViewModels
{
    public class AlbumDetailVM
    {
        public string Idalbum { get; set; } = null!;
        public string? TenAlbum { get; set; }
        public DateOnly? NgayRaMat { get; set; }
        public string? LinkAnh { get; set; }
        public string? IdtacGia { get; set; }
        public string? TenTG { get; set; }
        public List<BaiHatVM> BaiHats { get; set; } = new List<BaiHatVM>();
        public TacGiaVM? TacGia { get; set; }
    }
}
