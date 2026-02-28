namespace PersonalDiary.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        // User unique AES-256 key, base64
        public string EncryptionKey { get; set; } = string.Empty;

        // User unique AES IV, base64
        public string EncryptionIV { get; set; } = string.Empty;
    }
}