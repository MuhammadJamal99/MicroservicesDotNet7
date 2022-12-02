using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.MapperProfiles;

public class PlatformsProfiles : Profile
{
	public PlatformsProfiles()
	{
		//Source Platform Data Model -> Destination Platform Dto
		CreateMap<Platform, PlatformDto>();

        //Source PlatformCreateDto -> Destination Platform Data Model
		CreateMap<PlatformCreateDto, Platform>();

    }
}
