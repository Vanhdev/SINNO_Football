using BsonData;

namespace System
{
    public partial class DB
    {
        static public MainDatabase Main { get; private set; }
        static public void Start(string path)
        {
            Main = new MainDatabase("MainDB");
            Main.Connect(path);
            Main.StartStorageThread();
        }
    }
}
