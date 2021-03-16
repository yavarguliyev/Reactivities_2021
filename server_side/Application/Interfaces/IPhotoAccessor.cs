using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Application.Handlers.Photos;

namespace Application.Interfaces
{
  public interface IPhotoAccessor
  {
    Task<PhotoUploadResult> AddPhoto(IFormFile file);
    Task<string> DeletePhoto(string publicId);
  }
}