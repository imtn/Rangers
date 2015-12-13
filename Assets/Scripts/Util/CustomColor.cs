using UnityEngine;

namespace Assets.Scripts.Util
{
    public static class CustomColor
    {
        private const float MAX_RGBVal = 255.0f;

        public static Color Red = Convert255(255.0f, 0f, 0f);
        public static Color Green = Convert255(0f, 255.0f, 0f);
        public static Color Blue = Convert255(0f, 0f, 255.0f);
        public static Color Cyan = Convert255(0f, 255.0f, 255.0f);
        public static Color Yellow = Convert255(255.0f, 255.0f, 0f);
        public static Color Magenta = Convert255(255.0f, 0f, 255.0f);
        public static Color Orange = Convert255(255.0f, 127.5f, 0f);
        public static Color Chartreuse = Convert255(127.5f, 255.0f, 0f);
        public static Color Spring = Convert255(0f, 255.0f, 127.5f);
        public static Color Azure = Convert255(0f, 127.5f, 255.0f);
        public static Color Violet = Convert255(127.5f, 0f, 255.0f);
        public static Color Rose = Convert255(255.0f, 0f, 127.5f);
        public static Color White = Convert255(255.0f, 255.0f, 255.0f);
        public static Color Black = Convert255(0f, 0f, 0f);

        public static Color Convert255(float r, float g, float b)
        {
            r = Mathf.Clamp(r, 0f, MAX_RGBVal);
            g = Mathf.Clamp(g, 0f, MAX_RGBVal);
            b = Mathf.Clamp(b, 0f, MAX_RGBVal);
            return new Color((r / MAX_RGBVal), (g / MAX_RGBVal), (b / MAX_RGBVal));
        }

        public static Color Convert255(float r, float g, float b, float a)
        {
            r = Mathf.Clamp(r, 0f, MAX_RGBVal);
            g = Mathf.Clamp(g, 0f, MAX_RGBVal);
            b = Mathf.Clamp(b, 0f, MAX_RGBVal);
            a = Mathf.Clamp(a, 0f, MAX_RGBVal);
            return new Color((r / MAX_RGBVal), (g / MAX_RGBVal), (b / MAX_RGBVal), (a / MAX_RGBVal));
        }

        /*
        public static Color ColorFromElement(Enums.Element element)
        {
            switch (element)
            {
                case Enums.Element.Fire:
                    return Convert255(175.0f, 30.0f, 30.0f);
                case Enums.Element.Water:
                    return Convert255(30.0f, 30.0f, 175.0f);
                case Enums.Element.Thunder:
                    return Convert255(225.0f, 225.0f, 30.0f);
                case Enums.Element.Earth:
                    return Convert255(85.0f, 50.0f, 15.0f);
                case Enums.Element.Wood:
                    return Convert255(30.0f, 175.0f, 30.0f);
                default:
                    return Convert255(128.0f, 128.0f, 128.0f);
            }
        }
        */
    }
}