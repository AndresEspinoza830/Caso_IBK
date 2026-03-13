using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BFF.Application.Handlers.Queries.UserController
{
    public class GetProfileRequest : IRequest<GetProfileResponse>
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0")]
        public int IdUser { get; set; }
    }

}
