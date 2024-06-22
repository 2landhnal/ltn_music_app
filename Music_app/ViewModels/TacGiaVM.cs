namespace Music_app.ViewModels
{
    public class TacGiaVM
    {
        public string IdtacGia { get; set; } = null!;

        public string? TenTg { get; set; }

        public DateOnly? Ns { get; set; }

        public string? QueQuan { get; set; }

        public string? TieuSu { get; set; }

        public string? GioiTinh { get; set; }

        public string? LinkAnh { get; set; }
		public List<BaiHatVM> BaiHats { get; set; }
	}
}
