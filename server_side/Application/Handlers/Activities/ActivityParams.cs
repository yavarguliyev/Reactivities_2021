using System;
using Application.Core;

namespace Application.Handlers.Activities
{
  public class ActivityParams : PagingParams
  {
    public bool IsGoing { get; set; }
    public bool IsHost { get; set; }
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
  }
}