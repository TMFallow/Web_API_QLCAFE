using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanController : ControllerBase
    {
        private readonly IBanServices banServices;
        private readonly ILogger<Ban> logger;

        public BanController(IBanServices banServices, ILogger<Ban> logger)
        {
            this.banServices = banServices;
            this.logger = logger;
        }

        [HttpGet("GetAllBan")]
        public IEnumerable<Ban> GetAllBan()
        {
            return banServices.GetAllBan().ToArray();
        }

        [HttpGet("GetBanTheoMa/{MaBan}")]
        public Ban GetBanTheoMa(string MaBan)
        {
            return banServices.GetBan(MaBan);
        }
    }
}
