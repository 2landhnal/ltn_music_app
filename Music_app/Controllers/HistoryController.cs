using Microsoft.AspNetCore.Mvc;
using Music_app.Models;
using Music_app.Helpers;
using Microsoft.AspNetCore.Http;
using Music_app.ViewModels;

namespace Music_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly MyMusicContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HistoryController(MyMusicContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("SaveHistory")]
        public IActionResult SaveHistory([FromBody] SaveHistoryVM model)
        {
            if (model == null || string.IsNullOrEmpty(model.IdbaiHat))
            {
                return BadRequest("Invalid song data.");
            }
            var userId = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            // Kiểm tra xem UserId có tồn tại hay không
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("UserId không hợp lệ.");
            }
            // Tạo một đối tượng lịch sử từ dữ liệu ViewModel
            var history = new LichSu
            {
                Idls = Hash.GenerateShortGuid(),
                Iduser = userId,
                IdbaiHat = model.IdbaiHat,
                Thoigian = DateTime.Now
            };
            _context.LichSus.Add(history);
            _context.SaveChanges();

            return Ok();
        }

    }
}
