using Microsoft.AspNetCore.Mvc;
using Music_app.Models;
using Music_app.ViewModels;
using Music_app.Helpers;

namespace Music_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmotionController : ControllerBase
    {
        private readonly MyMusicContext _context;
       

        public EmotionController(MyMusicContext context)
        {
            _context = context;
            
        }
        [HttpPost("SaveEmotion")]
        public async Task<IActionResult> SaveEmotion([FromBody] EmotionRequest request)
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId == null)
            {
               
                return Unauthorized(new { Message = "User is not authenticated." });
            }
            if (request == null || string.IsNullOrEmpty(request.IdbaiHat) || string.IsNullOrEmpty(request.CamXuc1))
            {
                return BadRequest("Invalid request data.");
            }

           // var userId = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            var camXuc = new CamXuc
            {
                IdcamXuc = Hash.GenerateShortGuid(),
                IdbaiHat = request.IdbaiHat,
                CamXuc1 = request.CamXuc1,
                Iduser = userId,
                Thoigian = DateTime.UtcNow
            };

            _context.CamXucs.Add(camXuc);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Emotion saved successfully." });
        }
    }
}
