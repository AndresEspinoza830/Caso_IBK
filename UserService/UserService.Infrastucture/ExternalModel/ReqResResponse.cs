namespace UserService.Infrastucture.ExternalModel
{
    public class ReqResResponse
    {
        public ReqResUser Data { get; set; }
    }

    public class ReqResUser
    {
        public int Id { get; set; }
        public string Email { get; set; } = String.Empty;
        public string First_Name { get; set; } = String.Empty;
        public string Last_Name { get; set; } = String.Empty;
        public string Avatar { get; set; } = String.Empty;
    }


}
