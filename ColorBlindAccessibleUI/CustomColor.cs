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
        private static Color CustomBlack => new Color(0.01f, 0.01f, 0.01f, 1);

        public CustomColor(string name, Color color) => (Name, Color) = (name, color);

        public CustomColor(string name, uint color) => (Name, Color) = (name, Color.FromUint(color));

        public Color Color;

        public override string ToString() => Name;

        public static CustomColor[] ColorList = new CustomColor[]
        {
            new CustomColor("Black", CustomBlack),
            new CustomColor("Blue", Colors.Blue),
            new CustomColor("Cyan", Colors.Cyan),
            new CustomColor("Gray", Colors.Gray),
            new CustomColor("Green", Colors.Green),
            new CustomColor("Magenta", Colors.Magenta),
            new CustomColor("Red", Colors.Red),
            new CustomColor("White", Colors.White),
            new CustomColor("Yellow", Colors.Yellow),
            // hardcoded notification colors
            new CustomColor("Spanish Grey", 10066329U),
            new CustomColor("UFO Green", 2284902U),
            new CustomColor("Turquoise", 3407803U),
            new CustomColor("Vivid Red-Tangelo", 14509602U),
            new CustomColor("Deep Saffron", 16750899U),
            new CustomColor("Amethyst", 10053324U),
            new CustomColor("Shocking Pink", 15623935U),
            new CustomColor("Medium Orchid", 11163101U),
            new CustomColor("Gray (X11)", 12303291U),
            new CustomColor("Brass", 12298820U),
            new CustomColor("Telemagenta", 13382502U),
            new CustomColor("Electric Blue", 6745855U),
            new CustomColor("Carolina Blue", 5614301U),
            new CustomColor("Blue-Gray", 6724044U),
            new CustomColor("Deep Magenta", 13369548U)
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
                parsedColor = CustomBlack;

            return parsedColor;
        }
    }
}
