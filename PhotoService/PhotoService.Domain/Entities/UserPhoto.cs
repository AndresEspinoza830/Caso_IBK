namespace PhotoService.Domain.Entities
{
    public class UserPhoto
    {
        public int UserId { get; set; }

        public string ImageBase64 { get; set; } = string.Empty;
    }
}
