using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace Actors
{
    public partial class Admin : Account
    {
    }
    public partial class Member : Account
    {
        public static int SetTotalPoint(Document doc)
        {
            switch (doc.Position)
            {
                case "ST": return (int)Math.Round((doc.Pac * 0.2) + (doc.Sho * 0.35) + (doc.Pas * 0.1) + (doc.Dri * 0.1) + (doc.Def * 0.1) + (doc.Phy * 0.15), MidpointRounding.AwayFromZero);
                case "CM": return (int)Math.Round((doc.Pac * 0.1) + (doc.Sho * 0.15) + (doc.Pas * 0.35) + (doc.Dri * 0.15) + (doc.Def * 0.15) + (doc.Phy * 0.1), MidpointRounding.AwayFromZero);
                case "LB": case "RB": return (int)Math.Round((doc.Pac * 0.25) + (doc.Sho * 0.05) + (doc.Pas * 0.2) + (doc.Dri * 0.1) + (doc.Def * 0.25) + (doc.Phy * 0.15), MidpointRounding.AwayFromZero);
                case "CB": return (int)Math.Round((doc.Pac * 0.05) + (doc.Sho * 0.05) + (doc.Pas * 0.15) + (doc.Dri * 0.1) + (doc.Def * 0.4) + (doc.Phy * 0.25), MidpointRounding.AwayFromZero);
                case "GK": return (int)Math.Round((doc.Pas * 0.3) + (doc.GKH * 0.7), MidpointRounding.AwayFromZero);
                default: return 70;
            }
        }
    }
}
