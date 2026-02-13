namespace PersonalDiary.Services
{
    public class CurrentUserService
    {
        public int? UserId { get; set; }
        public string? Username { get; set; }

        public void SetUser(int id, string username)
        {
            UserId = id;
            Username = username;
        }

        public void Clear()
        {
            UserId = null;
            Username = null;
        }

        public bool IsAuthenticated => UserId.HasValue;
    }
}