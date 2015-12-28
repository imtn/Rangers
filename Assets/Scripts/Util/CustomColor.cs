using UnityEngine;

namespace Assets.Scripts.Util
{
    /// <summary>
    /// Used for overriding Unity's colors that go from 0-1
    /// </summary>
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

        /// <summary>
        /// Converts a color from 0-1 to 0-255
        /// </summary>
        /// <param name="r">The amount of red (0-255)</param>
        /// <param name="g">The amount of green (0-255)</param>
        /// <param name="b">The amount of blue (0-255)</param>
        /// <returns>Color created from inputs</returns>
        public static Color Convert255(float r, float g, float b)
        {
            r = Mathf.Clamp(r, 0f, MAX_RGBVal);
            g = Mathf.Clamp(g, 0f, MAX_RGBVal);
            b = Mathf.Clamp(b, 0f, MAX_RGBVal);
            return new Color((r / MAX_RGBVal), (g / MAX_RGBVal), (b / MAX_RGBVal));
        }

        /// <summary>
        /// Converts a color from 0-1 to 0-255
        /// </summary>
        /// <param name="r">The amount of red (0-255)</param>
        /// <param name="g">The amount of green (0-255)</param>
        /// <param name="b">The amount of blue (0-255)</param>
        /// <param name="a">The amount of alpha (0-255)</param>
        /// <returns>Color created from inputs</returns>
        public static Color Convert255(float r, float g, float b, float a)
        {
            r = Mathf.Clamp(r, 0f, MAX_RGBVal);
            g = Mathf.Clamp(g, 0f, MAX_RGBVal);
            b = Mathf.Clamp(b, 0f, MAX_RGBVal);
            a = Mathf.Clamp(a, 0f, MAX_RGBVal);
            return new Color((r / MAX_RGBVal), (g / MAX_RGBVal), (b / MAX_RGBVal), (a / MAX_RGBVal));
        }
    }
}