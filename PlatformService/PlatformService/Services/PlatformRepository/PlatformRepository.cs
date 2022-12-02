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

    public bool CreatePlatform(Platform NewItem)
    {
        if (NewItem == null) throw new ArgumentNullException(nameof(NewItem));
        Context.Add(NewItem);
        Context.SaveChanges();
        return Context.Platforms.Any(o => o.Id == NewItem.Id);
    }

    public IEnumerable<Platform> GetList()
    {
        return Context.Platforms.ToList();
    }

    public Platform GetPlatformById(int id)
    {
        return Context.Platforms.FirstOrDefault(o => o.Id == id);
    }

    public bool SavaChanges()
    {
        return (Context.SaveChanges() >= 0);
    } 
}
