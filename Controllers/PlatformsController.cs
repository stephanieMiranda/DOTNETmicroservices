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

          [HttpGet("{id}", Name = "GetPlatformById")]
          public ActionResult<PlatformReadDto> GetPlatformById(int id)
          {
               var platformitem = _repository.GetPlatformById(id);

               if(platformitem != null){
                    return Ok(_mapper.Map<PlatformReadDto>(platformitem));
               }

               return NotFound();
          }

          [HttpPost]
          public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
          {
               //if we were updating, we'd need to do more, but in this case, we're just adding something.
               var platformModel = _mapper.Map<Platform>(platformCreateDto);
               _repository.CreatePlatform(platformModel);
               _repository.SaveChanges();

               //pass back success, if it is successful: 201, URI, and 
               var PlatformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

               //returns the HTTP 201
               return CreatedAtRoute(nameof(GetPlatformById), new {Id = PlatformReadDto.Id}, PlatformReadDto);

          }
     }
}