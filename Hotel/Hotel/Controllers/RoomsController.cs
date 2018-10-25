using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Internal;
using Microsoft.CodeAnalysis.Operations;

namespace Hotel.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("2.0")]
    public class RoomsController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRooms))]
        [MapToApiVersion("1.0")]
        public IActionResult GetRooms()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRooms), null),
                version = HttpContext.ApiVersionProperties().ApiVersion.MajorVersion + "." + HttpContext.ApiVersionProperties().ApiVersion.MinorVersion

            };

            return Ok(response);
        }

        [HttpGet(Name = nameof(GetRoomsV2))]
        [MapToApiVersion("2.0")]
        public IActionResult GetRoomsV2()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoomsV2), null),
                version = HttpContext.ApiVersionProperties().ApiVersion.MajorVersion + "." + HttpContext.ApiVersionProperties().ApiVersion.MinorVersion

            };

            return Ok(response);
        }
    }
}
