using Newtonsoft.Json;
using TaleWorlds.Library;

namespace AccessibleColorUI
{
    public class Config
    {
        private Color _alliedColor;
        private Color _enemyColor;

        [JsonProperty("alliedColor")]
        public string AlliedColorString
        {
            set
            {
                _alliedColor = this.ParseColors(value);
            }
        }

        [JsonProperty("enemyColor")]
        public string EnemyColorString
        {
            set
            {
                _enemyColor = this.ParseColors(value);
            }
        }

        public Color GetAllyColor() { return _alliedColor; }
        public Color GetEnemyColor() { return _enemyColor; }

        private Color ParseColors(string value)
        {
            switch (value.ToLowerInvariant())
            {
                case "red":
                    // return Color.ConvertStringToColor("#870707FF");
                    return Colors.Red;
                case "green":
                    return Color.ConvertStringToColor("#245E05FF");
                case "blue":
                    return Colors.Blue;
                case "yellow":
                    return Colors.Yellow;
                case "cyan":
                    return Colors.Cyan;
                case "magenta":
                    return Colors.Magenta;
                case "purple":
                    return Color.ConvertStringToColor("#800080FF");
                case "orange":
                    return Color.ConvertStringToColor("#cc6600FF");
                case "pink":
                    return Color.ConvertStringToColor("#cc0052FF");
                case "brown":
                    return Color.ConvertStringToColor("#663300FF");
                case "white":
                    return Color.White;
                case "black":
                    return Color.Black;
                default:
                    if (value.Length == 6)
                        return Color.ConvertStringToColor("#" + value + "FF");
                    else if (value.Length == 7)
                        return Color.ConvertStringToColor(value + "FF");
                    else if (value.Length == 8)
                        return Color.ConvertStringToColor("#" + value);
                    else if (value.Length == 9)
                        return Color.ConvertStringToColor(value);
                    break;

            }

            return Color.Black;
        }

    }
}
