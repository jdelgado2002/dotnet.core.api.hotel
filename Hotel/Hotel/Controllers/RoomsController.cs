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
    [ApiVersion("1.0")]
    public class RoomsController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRooms))]
        public IActionResult GetRooms()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRooms), null),
                version = HttpContext.ApiVersionProperties().ApiVersion.MajorVersion + "." + HttpContext.ApiVersionProperties().ApiVersion.MinorVersion

            };

            return Ok(response);
        }
    }
}
