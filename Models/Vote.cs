using BsonData;

namespace System
{
    partial class Document
    {
    }
}

namespace System
{
    partial class DB
    {
        static public Collection Votes => Main.GetCollection(nameof(Votes));
    }
}