using System.ComponentModel;

namespace NHL.Data.Enums
{
    public enum TeamEnum
    {
        [Description("All Teams")]
        ALL,
        [Description("New Jersey Devils")]
        NJD = 1,
        [Description("New York Islanders")]
        NYI = 2,
        [Description("New York Rangers")]
        NYR = 3,
        [Description("Philadelphia Flyers")]
        PHI = 4,
        [Description("Pittsburgh Penguins")]
        PIT = 5,
        [Description("Boston Bruins")]
        BOS = 6,
        [Description("Buffalo Sabres")]
        BUF = 7,
        [Description("Montréal Canadiens")]
        MTL = 8,
        [Description("Ottawa Senators")]
        OTT = 9,
        [Description("Toronto Maple Leafs")]
        TOR = 10,
        [Description("Carolina Hurricanes")]
        CAR = 12,
        [Description("Florida Panthers")]
        FLA = 13,
        [Description("Tampa Bay Lightning")]
        TBL = 14,
        [Description("Washington Capitals")]
        WSH = 15,
        [Description("Chicago Blackhawks")]
        CHI = 16,
        [Description("Detroit Red Wings")]
        DET = 17,
        [Description("Nashville Predators")]
        NSH = 18,
        [Description("St. Louis Blues")]
        STL = 19,
        [Description("Calgary Flames")]
        CGY = 20,
        [Description("Colorado Avalanche")]
        COL = 21,
        [Description("Edmonton Oilers")]
        EDM = 22,
        [Description("Vancouver Canucks")]
        VAN = 23,
        [Description("Anaheim Ducks")]
        ANA = 24,
        [Description("Dallas Stars")]
        DAL = 25,
        [Description("Los Angeles Kings")]
        LAK = 26,
        [Description("San Jose Sharks")]
        SJS = 28,
        [Description("Columbus Blue Jackets")]
        CBJ = 29,
        [Description("Minnesota Wild")]
        MIN = 30,
        [Description("Winnipeg Jets")]
        WPG = 52,
        [Description("Arizona Coyotes")]
        ARI = 53,
        [Description("Vegas Golden Knights")]
        VGK = 54
    }
}