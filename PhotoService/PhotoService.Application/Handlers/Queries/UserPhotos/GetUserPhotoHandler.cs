using PhotoService.Application.Interfaces;
using MediatR;

namespace PhotoService.Application.Handlers.Queries.UserController
{
    public class QueryFindAllHandler(IPhotoRepository _photoRepository) : IRequestHandler<GetUserPhotoRequest, GetUserPhotoResponse>
    {
        public async Task<GetUserPhotoResponse> Handle(GetUserPhotoRequest request, CancellationToken cancellationToken)
        {
            var photo = await _photoRepository.GetUserPhoto(request.IdUser);

            return new GetUserPhotoResponse
            {
                UserId = photo.UserId,
                ImageBase64 = photo.ImageBase64
            };
        }
    }

}
