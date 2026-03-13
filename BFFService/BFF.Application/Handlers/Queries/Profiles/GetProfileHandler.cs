using BFF.Application.Interfaces;
using MediatR;

namespace BFF.Application.Handlers.Queries.UserController
{
    public class GetProfileHandler(IProfileRepository _profileRepository) : IRequestHandler<GetProfileRequest, GetProfileResponse>
    {
        public async Task<GetProfileResponse> Handle(GetProfileRequest request, CancellationToken cancellationToken)
        {
            var userTask =  _profileRepository.GetUser(request.IdUser);
            var photoTask =  _profileRepository.GetPhoto(request.IdUser);

            await Task.WhenAll(userTask, photoTask);

            var user = await userTask;
            var photo = await photoTask;

            return new GetProfileResponse
            {
                Id = user.Id,
                Name = user.Name,
                Photo = photo.Image
            };
        }
    }

}
