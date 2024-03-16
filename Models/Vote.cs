using BsonData;

namespace System
{
    partial class Document
    {
        public List<Document> Choices { get => GetArray<List<Document>>(nameof(Choices)); set => Push(nameof(Choices), value); }
        public DateTime? Deadline { get => GetDateTime(nameof(Deadline)); set => Push(nameof(Deadline), value); }
        public bool Active { get => GetValue<bool>(nameof(Active)); set => Push(nameof(Active), value); }
    }
}

namespace System
{
    partial class DB
    {
        static public Collection Votes => Main.GetCollection(nameof(Votes));
    }
}