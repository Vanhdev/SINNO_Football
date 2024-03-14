using BsonData;

namespace System
{
    partial class Document
    {
        public int TotalPoint { get => GetValue<int>(nameof(TotalPoint)); set => Push(nameof(TotalPoint), value); }
        public string Name { get => GetString(nameof(Name)); set => Push(nameof(Name), value); }
        public string Number { get => GetString(nameof(Number)); set => Push(nameof(Number), value); }
        public string Position { get => GetString(nameof(Position)); set => Push(nameof(Position), value); }

        //Thông số chi tiết
        public int Speed { get => GetValue<int>(nameof(Speed)); set => Push(nameof(Speed), value); }
        public int BallControl { get => GetValue<int>(nameof(BallControl)); set => Push(nameof(BallControl), value); }
        public int Finishing { get => GetValue<int>(nameof(Finishing)); set => Push(nameof(Finishing), value); }
        public int Positioning { get => GetValue<int>(nameof(Positioning)); set => Push(nameof(Positioning), value); }
        public int Passing { get => GetValue<int>(nameof(Passing)); set => Push(nameof(Passing), value); }
        public int Dribbling { get => GetValue<int>(nameof(Dribbling)); set => Push(nameof(Dribbling), value); }
        public int Vision { get => GetValue<int>(nameof(Vision)); set => Push(nameof(Vision), value); }
        public int Interception { get => GetValue<int>(nameof(Interception)); set => Push(nameof(Interception), value); }
        public int Tackling { get => GetValue<int>(nameof(Tackling)); set => Push(nameof(Tackling), value); }
        public int Stamina { get => GetValue<int>(nameof(Stamina)); set => Push(nameof(Stamina), value); }
        public int Strength { get => GetValue<int>(nameof(Strength)); set => Push(nameof(Strength), value); }
        public int Reflexes { get => GetValue<int>(nameof(Reflexes)); set => Push(nameof(Reflexes), value); }
        public int Kicking { get => GetValue<int>(nameof(Kicking)); set => Push(nameof(Kicking), value); }
        //Nhóm thông số
        public int Pac { get => GetValue<int>(nameof(Pac)); set => Push(nameof(Pac), value); }
        public int Sho { get => GetValue<int>(nameof(Sho)); set => Push(nameof(Sho), value); }
        public int Pas { get => GetValue<int>(nameof(Pas)); set => Push(nameof(Pas), value); }
        public int Dri { get => GetValue<int>(nameof(Dri)); set => Push(nameof(Dri), value); }
        public int Def { get => GetValue<int>(nameof(Def)); set => Push(nameof(Def), value); }
        public int Phy { get => GetValue<int>(nameof(Phy)); set => Push(nameof(Phy), value); }
        public int GKH { get => GetValue<int>(nameof(GKH)); set => Push(nameof(GKH), value); }
    }
}

namespace System
{
    partial class DB
    {
        static public Collection Members => Main.GetCollection(nameof(Members));
    }
}