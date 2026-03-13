namespace BFF.Application.Handlers.Queries.UserController
{
    public class GetProfileResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Photo { get; set; }
    }
}
