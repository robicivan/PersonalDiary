namespace PersonalDiary.Data
{
    public class DiaryEntry
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsEncrypted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        // Tags section
        public string Tags { get; set; } = string.Empty;

        public List<string> GetTagList() =>
            string.IsNullOrWhiteSpace(Tags)
                ? new List<string>()
                : Tags.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                      .ToList();
    }
}