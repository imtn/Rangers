using UnityEngine;

namespace Assets.Scripts.Util
{
	/// <summary>
	/// Used for convert normal colors to  Unity's colors that go from 0-1
	/// </summary>
	public static class CustomColor
	{
		private const float MAX_RGBVal = 255.0f;

		// Default colors
		// Grey levels
		public static Color Black = Convert255(0,0,0);
		public static Color Darkest_Grey = Convert255(31,31,31);
		public static Color Darker_Grey = Convert255(63,63,63);
		public static Color Dark_Grey = Convert255(95,95,95);
		public static Color Grey = Convert255(127,127,127);
		public static Color Light_Grey = Convert255(159,159,159);
		public static Color Lighter_Grey = Convert255(191,191,191);
		public static Color Lightest_Grey = Convert255(223,223,223);
		public static Color Darkest_Gray = Convert255(31,31,31);
		public static Color Darker_Gray = Convert255(63,63,63);
		public static Color Dark_Gray = Convert255(95,95,95);
		public static Color Gray = Convert255(127,127,127);
		public static Color Light_Gray = Convert255(159,159,159);
		public static Color Lighter_Gray = Convert255(191,191,191);
		public static Color Lightest_Gray = Convert255(223,223,223);
		public static Color White = Convert255(255,255,255);

		// Sepia
		public static Color Darkest_Sepia = Convert255(31,24,15);
		public static Color Darker_Sepia = Convert255(63,50,31);
		public static Color Dark_Sepia = Convert255(94,75,47);
		public static Color Sepia = Convert255(127,101,63);
		public static Color Light_Sepia = Convert255(158,134,100);
		public static Color Lighter_Sepia = Convert255(191,171,143);
		public static Color Lightest_Sepia = Convert255(222,211,195);

		// Standard colors
		public static Color Red = Convert255(255,0,0);
		public static Color Flame = Convert255(255,63,0);
		public static Color Orange = Convert255(255,127,0);
		public static Color Amber = Convert255(255,191,0);
		public static Color Yellow = Convert255(255,255,0);
		public static Color Lime = Convert255(191,255,0);
		public static Color Chartreuse = Convert255(127,255,0);
		public static Color Green = Convert255(0,255,0);
		public static Color Sea = Convert255(0,255,127);
		public static Color Turquoise = Convert255(0,255,191);
		public static Color Cyan = Convert255(0,255,255);
		public static Color Sky = Convert255(0,191,255);
		public static Color Azure = Convert255(0,127,255);
		public static Color Blue = Convert255(0,0,255);
		public static Color Han = Convert255(63,0,255);
		public static Color Violet = Convert255(127,0,255);
		public static Color Purple = Convert255(191,0,255);
		public static Color Fuchsia = Convert255(255,0,255);
		public static Color Magenta = Convert255(255,0,191);
		public static Color Pink = Convert255(255,0,127);
		public static Color Crimson = Convert255(255,0,63);

		// Dark colors
		public static Color Dark_Red = Convert255(191,0,0);
		public static Color Dark_Flame = Convert255(191,47,0);
		public static Color Dark_Orange = Convert255(191,95,0);
		public static Color Dark_Amber = Convert255(191,143,0);
		public static Color Dark_Yellow = Convert255(191,191,0);
		public static Color Dark_Lime = Convert255(143,191,0);
		public static Color Dark_Chartreuse = Convert255(95,191,0);
		public static Color Dark_Green = Convert255(0,191,0);
		public static Color Dark_Sea = Convert255(0,191,95);
		public static Color Dark_Turquoise = Convert255(0,191,143);
		public static Color Dark_Cyan = Convert255(0,191,191);
		public static Color Dark_Sky = Convert255(0,143,191);
		public static Color Dark_Azure = Convert255(0,95,191);
		public static Color Dark_Blue = Convert255(0,0,191);
		public static Color Dark_Han = Convert255(47,0,191);
		public static Color Dark_Violet = Convert255(95,0,191);
		public static Color Dark_Purple = Convert255(143,0,191);
		public static Color Dark_Fuchsia = Convert255(191,0,191);
		public static Color Dark_Magenta = Convert255(191,0,143);
		public static Color Dark_Pink = Convert255(191,0,95);
		public static Color Dark_Crimson = Convert255(191,0,47);

		// Darker colors
		public static Color Darker_Red = Convert255(127,0,0);
		public static Color Darker_Flame = Convert255(127,31,0);
		public static Color Darker_Orange = Convert255(127,63,0);
		public static Color Darker_Amber = Convert255(127,95,0);
		public static Color Darker_Yellow = Convert255(127,127,0);
		public static Color Darker_Lime = Convert255(95,127,0);
		public static Color Darker_Chartreuse = Convert255(63,127,0);
		public static Color Darker_Green = Convert255(0,127,0);
		public static Color Darker_Sea = Convert255(0,127,63);
		public static Color Darker_Turquoise = Convert255(0,127,95);
		public static Color Darker_Cyan = Convert255(0,127,127);
		public static Color Darker_Sky = Convert255(0,95,127);
		public static Color Darker_Azure = Convert255(0,63,127);
		public static Color Darker_Blue = Convert255(0,0,127);
		public static Color Darker_Han = Convert255(31,0,127);
		public static Color Darker_Violet = Convert255(63,0,127);
		public static Color Darker_Purple = Convert255(95,0,127);
		public static Color Darker_Fuchsia = Convert255(127,0,127);
		public static Color Darker_Magenta = Convert255(127,0,95);
		public static Color Darker_Pink = Convert255(127,0,63);
		public static Color Darker_Crimson = Convert255(127,0,31);

		// Darkest colors
		public static Color Darkest_Red = Convert255(63,0,0);
		public static Color Darkest_Flame = Convert255(63,15,0);
		public static Color Darkest_Orange = Convert255(63,31,0);
		public static Color Darkest_Amber = Convert255(63,47,0);
		public static Color Darkest_Yellow = Convert255(63,63,0);
		public static Color Darkest_Lime = Convert255(47,63,0);
		public static Color Darkest_Chartreuse = Convert255(31,63,0);
		public static Color Darkest_Green = Convert255(0,63,0);
		public static Color Darkest_Sea = Convert255(0,63,31);
		public static Color Darkest_Turquoise = Convert255(0,63,47);
		public static Color Darkest_Cyan = Convert255(0,63,63);
		public static Color Darkest_Sky = Convert255(0,47,63);
		public static Color Darkest_Azure = Convert255(0,31,63);
		public static Color Darkest_Blue = Convert255(0,0,63);
		public static Color Darkest_Han = Convert255(15,0,63);
		public static Color Darkest_Violet = Convert255(31,0,63);
		public static Color Darkest_Purple = Convert255(47,0,63);
		public static Color Darkest_Fuchsia = Convert255(63,0,63);
		public static Color Darkest_Magenta = Convert255(63,0,47);
		public static Color Darkest_Pink = Convert255(63,0,31);
		public static Color Darkest_Crimson = Convert255(63,0,15);

		// Light colors
		public static Color Light_Red = Convert255(255,114,114);
		public static Color Light_Flame = Convert255(255,149,114);
		public static Color Light_Orange = Convert255(255,184,114);
		public static Color Light_Amber = Convert255(255,219,114);
		public static Color Light_Yellow = Convert255(255,255,114);
		public static Color Light_Lime = Convert255(219,255,114);
		public static Color Light_Chartreuse = Convert255(184,255,114);
		public static Color Light_Green = Convert255(114,255,114);
		public static Color Light_Sea = Convert255(114,255,184);
		public static Color Light_Turquoise = Convert255(114,255,219);
		public static Color Light_Cyan = Convert255(114,255,255);
		public static Color Light_Sky = Convert255(114,219,255);
		public static Color Light_Azure = Convert255(114,184,255);
		public static Color Light_Blue = Convert255(114,114,255);
		public static Color Light_Han = Convert255(149,114,255);
		public static Color Light_Violet = Convert255(184,114,255);
		public static Color Light_Purple = Convert255(219,114,255);
		public static Color Light_Fuchsia = Convert255(255,114,255);
		public static Color Light_Magenta = Convert255(255,114,219);
		public static Color Light_Pink = Convert255(255,114,184);
		public static Color Light_Crimson = Convert255(255,114,149);

		//Lighter colors
		public static Color Lighter_Red = Convert255(255,165,165);
		public static Color Lighter_Flame = Convert255(255,188,165);
		public static Color Lighter_Orange = Convert255(255,210,165);
		public static Color Lighter_Amber = Convert255(255,232,165);
		public static Color Lighter_Yellow = Convert255(255,255,165);
		public static Color Lighter_Lime = Convert255(232,255,165);
		public static Color Lighter_Chartreuse = Convert255(210,255,165);
		public static Color Lighter_Green = Convert255(165,255,165);
		public static Color Lighter_Sea = Convert255(165,255,210);
		public static Color Lighter_Turquoise = Convert255(165,255,232);
		public static Color Lighter_Cyan = Convert255(165,255,255);
		public static Color Lighter_Sky = Convert255(165,232,255);
		public static Color Lighter_Azure = Convert255(165,210,255);
		public static Color Lighter_Blue = Convert255(165,165,255);
		public static Color Lighter_Han = Convert255(188,165,255);
		public static Color Lighter_Violet = Convert255(210,165,255);
		public static Color Lighter_Purple = Convert255(232,165,255);
		public static Color Lighter_Fuchsia = Convert255(255,165,255);
		public static Color Lighter_Magenta = Convert255(255,165,232);
		public static Color Lighter_Pink = Convert255(255,165,210);
		public static Color Lighter_Crimson = Convert255(255,165,188);

		// Lightest colors
		public static Color Lightest_Red = Convert255(255,191,191);
		public static Color Lightest_Flame = Convert255(255,207,191);
		public static Color Lightest_Orange = Convert255(255,223,191);
		public static Color Lightest_Amber = Convert255(255,239,191);
		public static Color Lightest_Yellow = Convert255(255,255,191);
		public static Color Lightest_Lime = Convert255(239,255,191);
		public static Color Lightest_Chartreuse = Convert255(223,255,191);
		public static Color Lightest_Green = Convert255(191,255,191);
		public static Color Lightest_Sea = Convert255(191,255,223);
		public static Color Lightest_Turquoise = Convert255(191,255,239);
		public static Color Lightest_Cyan = Convert255(191,255,255);
		public static Color Lightest_Sky = Convert255(191,239,255);
		public static Color Lightest_Azure = Convert255(191,223,255);
		public static Color Lightest_Blue = Convert255(191,191,255);
		public static Color Lightest_Han = Convert255(207,191,255);
		public static Color Lightest_Violet = Convert255(223,191,255);
		public static Color Lightest_Purple = Convert255(239,191,255);
		public static Color Lightest_Fuchsia = Convert255(255,191,255);
		public static Color Lightest_Magenta = Convert255(255,191,239);
		public static Color Lightest_Pink = Convert255(255,191,223);
		public static Color Lightest_Crimson = Convert255(255,191,207);

		// Desaturated colors
		public static Color Desaturated_Red = Convert255(127,63,63);
		public static Color Desaturated_Flame = Convert255(127,79,63);
		public static Color Desaturated_Orange = Convert255(127,95,63);
		public static Color Desaturated_Amber = Convert255(127,111,63);
		public static Color Desaturated_Yellow = Convert255(127,127,63);
		public static Color Desaturated_Lime = Convert255(111,127,63);
		public static Color Desaturated_Chartreuse = Convert255(95,127,63);
		public static Color Desaturated_Green = Convert255(63,127,63);
		public static Color Desaturated_Sea = Convert255(63,127,95);
		public static Color Desaturated_Turquoise = Convert255(63,127,111);
		public static Color Desaturated_Cyan = Convert255(63,127,127);
		public static Color Desaturated_Sky = Convert255(63,111,127);
		public static Color Desaturated_Azure = Convert255(63,95,127);
		public static Color Desaturated_Blue = Convert255(63,63,127);
		public static Color Desaturated_Han = Convert255(79,63,127);
		public static Color Desaturated_Violet = Convert255(95,63,127);
		public static Color Desaturated_Purple = Convert255(111,63,127);
		public static Color Desaturated_Fuchsia = Convert255(127,63,127);
		public static Color Desaturated_Magenta = Convert255(127,63,111);
		public static Color Desaturated_Pink = Convert255(127,63,95);
		public static Color Desaturated_Crimson = Convert255(127,63,79);

		// metallic
		public static Color Brass = Convert255(191,151,96);
		public static Color Copper = Convert255(197,136,124);
		public static Color Gold = Convert255(229,191,0);
		public static Color Silver = Convert255(203,203,203);

		// miscellaneous
		public static Color Celadon = Convert255(172,255,175);
		public static Color Peach = Convert255(255,159,127);

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