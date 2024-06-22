using System.ComponentModel.DataAnnotations;

namespace Music_app.ViewModels
{
	public class TaiKhoanVM
	{
		[Key]
		[Required(ErrorMessage ="*")]
		public string TenTk { get; set; } = null!;

		[DataType(DataType.Password)]
		public string MatKhau { get; set; }

		public string? Iduser { get; set; }
	}
}
