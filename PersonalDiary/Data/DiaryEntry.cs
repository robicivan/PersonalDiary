namespace PersonalDiary.Data
{
    public class DiaryEntry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EncryptedContent { get; set; }
        public bool IsEncrypted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}