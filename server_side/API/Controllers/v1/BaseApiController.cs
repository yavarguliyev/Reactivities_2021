using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Core;
using API.Extensions;

namespace API.Controllers.v1
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class BaseApiController : ControllerBase
  {
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    protected ActionResult HandleResult<T>(Result<T> result)
    {
      if (result == null) return NotFound();
      if (result.IsSuccess && result.Value != null)
        return Ok(result.Value);
      if (result.IsSuccess && result.Value == null)
        return NotFound();
      return BadRequest(result.Error);
    }

    protected ActionResult HandlePagedResult<T>(Result<PagedList<T>> result)
    {
      if (result == null) return NotFound();
      if (result.IsSuccess && result.Value != null)
      {
        Response.AddPaginationHeader(result.Value.CurrentPage, result.Value.PageSize,
            result.Value.TotalCount, result.Value.TotalPages);
        return Ok(result.Value);
      }
      if (result.IsSuccess && result.Value == null)
        return NotFound();
      return BadRequest(result.Error);
    }
  }
}