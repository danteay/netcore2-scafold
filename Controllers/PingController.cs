using Microsoft.AspNetCore.Mvc;
using App.Models;

namespace App.Controllers
{
    [Route("/[controller]")]
    public class PingController : BaseController
    {
        // GET /ping
        [HttpGet]
        public JsonResult Get()
        {
            return Json(new Response().Get(
                200,
                "success",
                "OK",
                "/ping",
                "pong"
            ));
        }
    }
}
