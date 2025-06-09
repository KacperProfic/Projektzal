namespace Projekt_zaliczenie.Models;

public class Mission
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RocketStatusId { get; set; }
    public int MissionStatusId { get; set; }
    public DateTime LaunchDate { get; set; }

    
    public RocketStatus RocketStatus { get; set; }
    public MissionStatus MissionStatus { get; set; }
}