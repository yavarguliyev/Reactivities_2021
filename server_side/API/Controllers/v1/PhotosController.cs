using System.Threading.Tasks;
using Application.Handlers.Photos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
  public class PhotosController : BaseApiController
  {
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] Add.Command command)
    {
      return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
      return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
    }

    [HttpPost("{id}/setMain")]
    public async Task<IActionResult> SetMain(string id)
    {
      return HandleResult(await Mediator.Send(new SetMain.Command { Id = id }));
    }
  }
}