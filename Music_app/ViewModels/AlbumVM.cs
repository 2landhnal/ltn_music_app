using Music_app.Models;

namespace Music_app.ViewModels
{
    public class AlbumVM
    {
        public string Idalbum { get; set; } = null!;

        public string? TenAlbum { get; set; }

        public DateOnly? NgayRaMat { get; set; }

        public string? LinkAnh { get; set; }

        public string? IdtacGia { get; set; }

        public virtual ICollection<Ctalbum> Ctalbums { get; set; } = new List<Ctalbum>();

        public virtual TacGium? IdtacGiaNavigation { get; set; }
		public string? TenTG { get; set; }
	}
}
