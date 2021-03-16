using System.Threading.Tasks;
using Application.Handlers.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
  public class ProfilesController : BaseApiController
  {
    [HttpGet("{username}")]
    public async Task<IActionResult> GetProfile(string username)
    {
      return HandleResult(await Mediator.Send(new Details.Query { Username = username }));
    }

    [HttpPut]
    public async Task<IActionResult> Edit(Edit.Command command)
    {
      return HandleResult(await Mediator.Send(command));
    }
  }
}