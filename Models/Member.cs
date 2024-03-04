using BsonData;

namespace System
{
    partial class Document
    {
        public int TotalPoint { get => GetValue<int>(nameof(TotalPoint)); set => Push(nameof(TotalPoint), value); }
        public string Name { get => GetString(nameof(Name)); set => Push(nameof(Name), value); }
        public string Number { get => GetString(nameof(Number)); set => Push(nameof(Number), value); }
        public string Position { get => GetString(nameof(Position)); set => Push(nameof(Position), value); }
        public int Speed { get => GetValue<int>(nameof(Speed)); set => Push(nameof(Speed), value); }
        public int Acceleration { get => GetValue<int>(nameof(Acceleration)); set => Push(nameof(Acceleration), value); }
        public int Shoot { get => GetValue<int>(nameof(Shoot)); set => Push(nameof(Shoot), value); }
        public int Positioning { get => GetValue<int>(nameof(Positioning)); set => Push(nameof(Positioning), value); }
        public int ShortPass { get => GetValue<int>(nameof(ShortPass)); set => Push(nameof(ShortPass), value); }
        public int LongPass { get => GetValue<int>(nameof(LongPass)); set => Push(nameof(LongPass), value); }
        public int Vision { get => GetValue<int>(nameof(Vision)); set => Push(nameof(Vision), value); }
        public int Crossing { get => GetValue<int>(nameof(Crossing)); set => Push(nameof(Crossing), value); }
    }
}

namespace System
{
    partial class DB
    {
        static public Collection Members => Main.GetCollection(nameof(Members));
    }
}