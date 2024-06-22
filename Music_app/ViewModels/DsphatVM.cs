namespace Music_app.ViewModels
{
	public class DsphatVM
	{
		public string Iddsphat { get; set; } = null!;
		public string? TenDsphat { get; set; }
		public DateTime? ThoiGian { get; set; }
		public string? Iduser { get; set; }
		public ICollection<BaiHatVM> BaiHats { get; set; } = new List<BaiHatVM>();
	}
}
