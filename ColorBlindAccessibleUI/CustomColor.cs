using Newtonsoft.Json;
using System.Linq;
using TaleWorlds.Library;

namespace ColorBlindAccessibleUI
{
    public class CustomColor
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("hexcode")]
        public string HexCode
        {
            set
            {
                Color = this.ParseColorCode(value);
            }
        }

        public CustomColor(string name, Color color) => (Name, Color) = (name, color);

        public Color Color;

        public override string ToString() => Name;

        public static CustomColor[] ColorList = new CustomColor[]
        {
            new CustomColor("Black", Colors.Black),
            new CustomColor("Blue", Colors.Blue),
            new CustomColor("Cyan", Colors.Cyan),
            new CustomColor("Gray", Colors.Gray),
            new CustomColor("Green", Colors.Green),
            new CustomColor("Magenta", Colors.Magenta),
            new CustomColor("Red", Colors.Red),
            new CustomColor("White", Colors.White),
            new CustomColor("Yellow", Colors.Yellow)
        };

        public static void AddColor(string name, string hexCode)
        {
            var color = Color.ConvertStringToColor(hexCode);
            CustomColor.ColorList = CustomColor.ColorList.Append(new CustomColor(name, color)).ToArray();
        }

        public static void AddColor(CustomColor color)
        {
            CustomColor.ColorList = CustomColor.ColorList.Append(color).ToArray();
        }

        public static void AddColors(CustomColor[] colors)
        {
            CustomColor.ColorList = CustomColor.ColorList.Concat(colors).ToArray();
        }

        private Color ParseColorCode(string value)
        {
            if (value.Length == 6)
                return Color.ConvertStringToColor("#" + value + "FF");
            else if (value.Length == 7)
                return Color.ConvertStringToColor(value + "FF");
            else if (value.Length == 8)
                return Color.ConvertStringToColor("#" + value);
            else if (value.Length == 9)
                return Color.ConvertStringToColor(value);
            else
                return Colors.Black;
        }
    }
}
