namespace UserService.Application.Handlers.Queries.UserController
{
    public class GetUserResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Avatar { get; set; } = String.Empty;
    }
}
