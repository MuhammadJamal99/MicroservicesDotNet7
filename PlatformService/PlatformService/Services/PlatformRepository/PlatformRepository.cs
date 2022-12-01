using PlatformService.Data;
using PlatformService.Models;

namespace PlatformService.Services.PlatformRepository;

public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext Context;

    public PlatformRepository(AppDbContext context)
    {
        Context = context; 
    }

    public void CreatePlatform(Platform NewItem)
    {
        if (NewItem == null) throw new ArgumentNullException(nameof(NewItem));
        Context.Add(NewItem);
    }

    public IEnumerable<Platform> GetList()
    {
        return Context.Platform.ToList();
    }

    public Platform GetPlatformById(int id)
    {
        return Context.Platform.FirstOrDefault(o => o.Id == id);
    }

    public bool SavaChanges()
    {
        return (Context.SaveChanges() >= 0);
    } 
}
