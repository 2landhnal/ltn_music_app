namespace Music_app.ViewModels
{
	public class UserVM
	{
		public string Iduser { get; set; } = null!;

		public string TenUser { get; set; }

		public string GioiTinh { get; set; } 

		public string? QuocTich { get; set; }

		public string? Sdt { get; set; }

		public DateOnly? NgaySinh { get; set; }
	}
}
