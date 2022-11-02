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
            new CustomColor("Black", new Color(0.01f, 0.01f, 0.01f, 1)),
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

        /// <summary>
        /// Parses the supplied hexcode if it matches the supported formats.
        /// Note that Color.Black is unsupported because it results in null color tips.
        /// A Black color will result in a slightly modified version that won't exactly
        /// match the hardcoded Colors.Black to avoid the bugs caused by null color tips.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Parsed color, default is Gray</returns>
        private Color ParseColorCode(string value)
        {
            Color parsedColor;
            if (value.Length == 6)
                parsedColor = Color.ConvertStringToColor("#" + value + "FF");
            else if (value.Length == 7)
                parsedColor = Color.ConvertStringToColor(value + "FF");
            else if (value.Length == 8)
                parsedColor = Color.ConvertStringToColor("#" + value);
            else if (value.Length == 9)
                parsedColor = Color.ConvertStringToColor(value);
            else
                parsedColor = Colors.Gray;

            if (parsedColor == Color.Black)
                parsedColor = new Color(0.01f, 0.01f, 0.01f, 1);

            return parsedColor;
        }
    }
}
