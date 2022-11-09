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
            new CustomColor("Spanish Grey", 4288256409),
            new CustomColor("UFO Green", 4280474982),
            new CustomColor("Turquoise", 4281597883),
            new CustomColor("Vivid Red-Tangelo", 4292699682),
            new CustomColor("Deep Saffron", 4294940979),
            new CustomColor("Amethyst", 4288243404),
            new CustomColor("Shocking Pink", 4293814015),
            new CustomColor("Medium Orchid", 4289353181),
            new CustomColor("Gray (X11)", 4290493371),
            new CustomColor("Brass", 4290488900),
            new CustomColor("Telemagenta", 4291572582),
            new CustomColor("Electric Blue", 4284935935),
            new CustomColor("Carolina Blue", 4283804381),
            new CustomColor("Blue-Gray", 4284914124),
            new CustomColor("Deep Magenta", 4291559628)
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
