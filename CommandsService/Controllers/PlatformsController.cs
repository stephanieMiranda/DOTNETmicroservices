using System;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
     //the route helps to make distinct routes w/ api gateway
     [Route("api/c/[controller]")]
     [ApiController]
    public class PlatformsController : ControllerBase
    {
         public PlatformsController()
         {
             
         }

          [HttpPost]
         public ActionResult TestInboundConnection(){
              Console.WriteLine("---> Inboud POST # Commnad Serivce");

              return Ok("Inboud test of from Platforms Controller.");
         }
    }
}