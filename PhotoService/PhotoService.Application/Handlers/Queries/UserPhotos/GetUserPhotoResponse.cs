namespace PhotoService.Application.Handlers.Queries.UserController
{
    public class GetUserPhotoResponse
    {
        public int UserId { get; set; }

        public string ImageBase64 { get; set; } = String.Empty;
    }
}
