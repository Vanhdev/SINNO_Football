using BsonData;
using System.Net.WebSockets;

namespace Actors
{
    public class Account : Document
    {
        static public Account CreateOne(string userName, string password, string role)
        {
            var acc = new Account { 
                Username = userName,
                Password = (userName + password).ToMD5(),
                Role = role
            };

            return acc;
        }
    }
}

namespace System
{
    partial class Document
    {
        public string Username { get => ObjectId; set => ObjectId = value; }
        public string Password { get => GetString(nameof(Password)); set => Push(nameof(Password), value); }
        public string Token { get => GetString(nameof(Token)); set => Push(nameof(Token), value); }
        public string Role { get => GetString(nameof(Role)); set => Push(nameof(Role), value); }
    }

    partial class DB
    {
        static Collection? _accounts;
        static public Collection Accounts
        {
            get
            {
                if (_accounts == null)
                {
                    _accounts = Main.GetCollection(nameof(Accounts));
                    if (_accounts.Find("admin") == null)
                    {
                        var acc = Actors.Account.CreateOne("sinnofc", "CR7isgoat", "Admin");
                        _accounts.Insert(acc);
                    }
                }

                return _accounts;
            }
        }
    }
}