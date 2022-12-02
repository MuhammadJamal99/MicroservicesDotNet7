using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos;

public class PlatformDto
{
    public required int Id { get; set; }
    public string Name { get; set; }
    public string Publisher { get; set; }
    public string Cost { get; set; }
}
