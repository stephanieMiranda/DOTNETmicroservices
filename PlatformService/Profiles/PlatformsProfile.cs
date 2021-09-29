using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles
{
     public class PlatformsProfile : Profile
     {
          public PlatformsProfile()
          {
              //we create the mappings here <Source -> Target>
              CreateMap<Platform, PlatformReadDto>();
              CreateMap<PlatformCreateDto, Platform>();
          }
     }
}