namespace Music_app.ViewModels
{
	public class XemAlbumVM
	{
		public IEnumerable<BaiHatVM> BaiHatVMs { get; set; }
		public IEnumerable<TacGiaVM> TacGiaVMs { get; set; }
		public IEnumerable<AlbumVM> AlbumVMs { get; set; }
	}
}
