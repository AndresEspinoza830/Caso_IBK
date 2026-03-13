using MediatR;

namespace PhotoService.Application.Handlers.Queries.UserController
{
    public class GetUserPhotoRequest : IRequest<GetUserPhotoResponse>
    {
        public int IdUser { get; set; }
    }

}
