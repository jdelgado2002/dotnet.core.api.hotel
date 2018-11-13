using Microsoft.AspNetCore.Mvc;
using Hotel.Models;
using Microsoft.Extensions.Options;

namespace Hotel.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class InfoController : ControllerBase
    {
        private readonly HotelInfo _hotelInfo;
        public InfoController(IOptions<HotelInfo> hotelInfoWrapper)
        {
            _hotelInfo = hotelInfoWrapper.Value;
        }

        [HttpGet(Name = nameof(GetHotelInfo))]
        [ProducesResponseType(200)]
        public ActionResult<HotelInfo> GetHotelInfo()
        {
            //TODO: move to DB
            var HotelInfo = new HotelInfo()
            {
                Title = "Villa Maria Luisa, tus mejores vacaciones",
                TagLine = "Welcome to an amazing vacation",
                Email = "jdelgado2002@gmail.com",
                Website = "villamarialuisa.net"
            };
            HotelInfo.Href = Url.Link(nameof(GetHotelInfo), null);
            HotelInfo.version = HttpContext.ApiVersionProperties().ApiVersion.MajorVersion + "." + HttpContext.ApiVersionProperties().ApiVersion.MinorVersion;
            return HotelInfo;
        }

    }
}