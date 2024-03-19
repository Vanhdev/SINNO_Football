using BsonData;

namespace System
{
    partial class Document
    {
        public DateTime? Date { get => GetDateTime(nameof(Date)); set => Push(nameof(Date), value); }
        public List<KeyValuePair<string, bool>> MemberVote { get => GetArray<List<KeyValuePair<string, bool>>>(nameof(MemberVote)); set => Push(nameof(MemberVote), value); }
        public bool ChoiceResponse { get => GetValue<bool>(nameof(ChoiceResponse)); set => Push(nameof(ChoiceResponse), value); }
        public string? Label { get => GetString(nameof(Label)); set => Push(nameof(Label), value); }
    }
}

namespace System
{
    partial class DB
    {
        static public Collection Choices => Main.GetCollection(nameof(Choices));
    }
}