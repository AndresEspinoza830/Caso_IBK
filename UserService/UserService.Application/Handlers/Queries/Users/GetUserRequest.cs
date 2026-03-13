using MediatR;

namespace UserService.Application.Handlers.Queries.UserController
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        public int IdUser { get; set; }
    }

}
