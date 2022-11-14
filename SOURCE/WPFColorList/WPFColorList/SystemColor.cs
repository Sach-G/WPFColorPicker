using System.Drawing;

namespace WPFColorList
{
    public class SystemColor
    {
        public Color Color { get; set; }
        public string ColorName
        {
            get
            {
                return Color.Name;
            }
        }

        public string Hex { get { return Color.ToHexString(); } }

        public string HexA { get { return Color.ToHexAString(); } }

        public string RGB { get { return Color.ToRGBString(); } }

        public string RGBA { get { return Color.ToRGBAString(); } }

        public SystemColor(Color color)
        {
            Color = color;
        }
    }

    public static class ColorConverterExtensions
    {
        // #RRGGBB
        public static string ToHexString(this Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";

        // #RRGGBBAA
        public static string ToHexAString(this Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}{c.A:X2}";

        // RGB(R, G, B)
        public static string ToRGBString(this Color c) => $"{c.R}, {c.G}, {c.B}";

        // RGBA(R, G, B, A)
        public static string ToRGBAString(this Color c) => $"{c.R}, {c.G}, {c.B}, {ToProportion(c.A):N2}";

        public static double ToProportion(byte b) => b / (double)byte.MaxValue;
    }
}
