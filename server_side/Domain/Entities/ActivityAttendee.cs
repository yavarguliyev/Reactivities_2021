using System;

namespace Domain.Entities
{
  public class ActivityAttendee
  {
    public string AppUserId { get; set; }
    public bool IsHost { get; set; }
    public Guid ApctivityId { get; set; }
    public AppUser AppUser { get; set; }
    public Activity Activity { get; set; }
  }
}