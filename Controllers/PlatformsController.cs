using System;
using System.Collections.Generic;
//using System.Runtime.Remoting.Messaging;
//using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
//using PlatformService.AsyncDataServices;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
//using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class PlatformsController : ControllerBase
     {
          private readonly IPlatformRepo _repository;
          private readonly IMapper _mapper;
          public PlatformsController(IPlatformRepo repository, IMapper mapper)
          {
              _repository = repository;
              _mapper = mapper;
          }

          //CRUD actions
          [HttpGet]
          public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
          {
               Console.WriteLine("--> Getting Platforms...");

               var platformItem = _repository.GetAllPlatforms();

               return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
          }
     }
}