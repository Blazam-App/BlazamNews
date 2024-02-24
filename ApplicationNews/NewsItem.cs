using System.Reflection.PortableExecutable;

namespace ApplicationNews
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
        public DateTime? DeletedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public byte[]? Icon { get; set; }
        public string? Link { get; set; }
        public bool DevOnly { get; set; }
        public bool Published { get; set; }


        public void CopyFrom(NewsItem other)
        {
            Title = other.Title;
            Body = other.Body;
            CreatedAt = other.CreatedAt;
            ScheduledAt = other.ScheduledAt;
            UpdatedAt = other.UpdatedAt;
            DeletedAt = other.DeletedAt;
            Icon = other.Icon;
            ExpiresAt = other.ExpiresAt;
            Link = other.Link;
            DevOnly = other.DevOnly;
            Published = other.Published;
        }
    }
}
