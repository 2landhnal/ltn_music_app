namespace Music_app.ViewModels
{
    public class DsgoiYVM
    {
        public string IddsgoiY { get; set; } = null!;
        public string? TenDsgoiY { get; set; }
        public string? Iduser { get; set; }
        public List<BaiHatVM> BaiHats { get; set; } = new List<BaiHatVM>();
    }
}
