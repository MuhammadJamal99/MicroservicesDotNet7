using PlatformService.Models;

namespace PlatformService.Services.PlatformRepository;

public interface IPlatformRepository
{
    bool SavaChanges();
    IEnumerable<Platform> GetList();
    Platform GetPlatformById(int id);
    bool CreatePlatform(Platform NewItem);
}
