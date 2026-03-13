using UserService.Application.Interfaces;
using MediatR;

namespace UserService.Application.Handlers.Queries.UserController
{
    public class QueryFindAllHandler(IUserRepository _userRepository) : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(request.IdUser);

            return new GetUserResponse
            {
                Id = user.Id,
                Name = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                Avatar = user.Avatar
            };
        }
    }

}
