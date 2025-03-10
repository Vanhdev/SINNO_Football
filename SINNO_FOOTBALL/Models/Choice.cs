using BsonData;

namespace System;

partial class Document
{
    public DateTime? Date { get => GetDateTime(nameof(Date)); set => Push(nameof(Date), value); }
    public List<string> Members { get => GetArray<List<string>>(nameof(Members)); set => Push(nameof(Members), value); }
    public bool ChoiceResponse { get => GetValue<bool>(nameof(ChoiceResponse)); set => Push(nameof(ChoiceResponse), value); }
};

partial class DB
{
    static public Collection Choices => Main.GetCollection(nameof(Choices));
}