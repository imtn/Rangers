using UnityEngine;
using System.Reflection;

namespace Assets.Scripts.Util
{
	/// <summary>
	/// Used for convert normal colors to  Unity's colors that go from 0-1
	/// </summary>
	public class CustomColor
	{
		public CustomColor(){}

		private const float MAX_RGBVal = 255.0f;

        #region Colors
        // Default colors
        // Grey levels
        private static Color black = Convert255(0,0,0);
		private static Color darkest_grey = Convert255(31,31,31);
		private static Color darker_grey = Convert255(63,63,63);
		private static Color dark_grey = Convert255(95,95,95);
		private static Color grey = Convert255(127,127,127);
		private static Color light_grey = Convert255(159,159,159);
		private static Color lighter_grey = Convert255(191,191,191);
		private static Color lightest_grey = Convert255(223,223,223);
		private static Color darkest_gray = Convert255(31,31,31);
		private static Color darker_gray = Convert255(63,63,63);
		private static Color dark_gray = Convert255(95,95,95);
		private static Color gray = Convert255(127,127,127);
		private static Color light_gray = Convert255(159,159,159);
		private static Color lighter_gray = Convert255(191,191,191);
		private static Color lightest_gray = Convert255(223,223,223);
		private static Color white = Convert255(255,255,255);

		// Sepia
		private static Color darkest_sepia = Convert255(31,24,15);
		private static Color darker_sepia = Convert255(63,50,31);
		private static Color dark_sepia = Convert255(94,75,47);
		private static Color sepia = Convert255(127,101,63);
		private static Color light_sepia = Convert255(158,134,100);
		private static Color lighter_sepia = Convert255(191,171,143);
		private static Color lightest_sepia = Convert255(222,211,195);

		// Standard colors
		private static Color red = Convert255(255,0,0);
		private static Color flame = Convert255(255,63,0);
		private static Color orange = Convert255(255,127,0);
		private static Color amber = Convert255(255,191,0);
		private static Color yellow = Convert255(255,255,0);
		private static Color lime = Convert255(191,255,0);
		private static Color chartreuse = Convert255(127,255,0);
		private static Color green = Convert255(0,255,0);
		private static Color sea = Convert255(0,255,127);
		private static Color turquoise = Convert255(0,255,191);
		private static Color cyan = Convert255(0,255,255);
		private static Color sky = Convert255(0,191,255);
		private static Color azure = Convert255(0,127,255);
		private static Color blue = Convert255(0,0,255);
		private static Color han = Convert255(63,0,255);
		private static Color violet = Convert255(127,0,255);
		private static Color purple = Convert255(191,0,255);
		private static Color fuchsia = Convert255(255,0,255);
		private static Color magenta = Convert255(255,0,191);
		private static Color pink = Convert255(255,0,127);
		private static Color crimson = Convert255(255,0,63);

		// Dark colors
		private static Color dark_red = Convert255(191,0,0);
		private static Color dark_flame = Convert255(191,47,0);
		private static Color dark_orange = Convert255(191,95,0);
		private static Color dark_amber = Convert255(191,143,0);
		private static Color dark_yellow = Convert255(191,191,0);
		private static Color dark_lime = Convert255(143,191,0);
		private static Color dark_chartreuse = Convert255(95,191,0);
		private static Color dark_green = Convert255(0,191,0);
		private static Color dark_sea = Convert255(0,191,95);
		private static Color dark_turquoise = Convert255(0,191,143);
		private static Color dark_cyan = Convert255(0,191,191);
		private static Color dark_sky = Convert255(0,143,191);
		private static Color dark_azure = Convert255(0,95,191);
		private static Color dark_blue = Convert255(0,0,191);
		private static Color dark_han = Convert255(47,0,191);
		private static Color dark_violet = Convert255(95,0,191);
		private static Color dark_purple = Convert255(143,0,191);
		private static Color dark_fuchsia = Convert255(191,0,191);
		private static Color dark_magenta = Convert255(191,0,143);
		private static Color dark_pink = Convert255(191,0,95);
		private static Color dark_crimson = Convert255(191,0,47);

		// Darker colors
		private static Color darker_red = Convert255(127,0,0);
		private static Color darker_flame = Convert255(127,31,0);
		private static Color darker_orange = Convert255(127,63,0);
		private static Color darker_amber = Convert255(127,95,0);
		private static Color darker_yellow = Convert255(127,127,0);
		private static Color darker_lime = Convert255(95,127,0);
		private static Color darker_chartreuse = Convert255(63,127,0);
		private static Color darker_green = Convert255(0,127,0);
		private static Color darker_sea = Convert255(0,127,63);
		private static Color darker_turquoise = Convert255(0,127,95);
		private static Color darker_cyan = Convert255(0,127,127);
		private static Color darker_sky = Convert255(0,95,127);
		private static Color darker_azure = Convert255(0,63,127);
		private static Color darker_blue = Convert255(0,0,127);
		private static Color darker_han = Convert255(31,0,127);
		private static Color darker_violet = Convert255(63,0,127);
		private static Color darker_purple = Convert255(95,0,127);
		private static Color darker_fuchsia = Convert255(127,0,127);
		private static Color darker_magenta = Convert255(127,0,95);
		private static Color darker_pink = Convert255(127,0,63);
		private static Color darker_crimson = Convert255(127,0,31);

		// Darkest colors
		private static Color darkest_red = Convert255(63,0,0);
		private static Color darkest_flame = Convert255(63,15,0);
		private static Color darkest_orange = Convert255(63,31,0);
		private static Color darkest_amber = Convert255(63,47,0);
		private static Color darkest_yellow = Convert255(63,63,0);
		private static Color darkest_lime = Convert255(47,63,0);
		private static Color darkest_chartreuse = Convert255(31,63,0);
		private static Color darkest_green = Convert255(0,63,0);
		private static Color darkest_sea = Convert255(0,63,31);
		private static Color darkest_turquoise = Convert255(0,63,47);
		private static Color darkest_cyan = Convert255(0,63,63);
		private static Color darkest_sky = Convert255(0,47,63);
		private static Color darkest_azure = Convert255(0,31,63);
		private static Color darkest_blue = Convert255(0,0,63);
		private static Color darkest_han = Convert255(15,0,63);
		private static Color darkest_violet = Convert255(31,0,63);
		private static Color darkest_purple = Convert255(47,0,63);
		private static Color darkest_fuchsia = Convert255(63,0,63);
		private static Color darkest_magenta = Convert255(63,0,47);
		private static Color darkest_pink = Convert255(63,0,31);
		private static Color darkest_crimson = Convert255(63,0,15);

		// Light colors
		private static Color light_red = Convert255(255,114,114);
		private static Color light_flame = Convert255(255,149,114);
		private static Color light_orange = Convert255(255,184,114);
		private static Color light_amber = Convert255(255,219,114);
		private static Color light_yellow = Convert255(255,255,114);
		private static Color light_lime = Convert255(219,255,114);
		private static Color light_chartreuse = Convert255(184,255,114);
		private static Color light_green = Convert255(114,255,114);
		private static Color light_sea = Convert255(114,255,184);
		private static Color light_turquoise = Convert255(114,255,219);
		private static Color light_cyan = Convert255(114,255,255);
		private static Color light_sky = Convert255(114,219,255);
		private static Color light_azure = Convert255(114,184,255);
		private static Color light_blue = Convert255(114,114,255);
		private static Color light_han = Convert255(149,114,255);
		private static Color light_violet = Convert255(184,114,255);
		private static Color light_purple = Convert255(219,114,255);
		private static Color light_fuchsia = Convert255(255,114,255);
		private static Color light_magenta = Convert255(255,114,219);
		private static Color light_pink = Convert255(255,114,184);
		private static Color light_crimson = Convert255(255,114,149);

		//Lighter colors
		private static Color lighter_red = Convert255(255,165,165);
		private static Color lighter_flame = Convert255(255,188,165);
		private static Color lighter_orange = Convert255(255,210,165);
		private static Color lighter_amber = Convert255(255,232,165);
		private static Color lighter_yellow = Convert255(255,255,165);
		private static Color lighter_lime = Convert255(232,255,165);
		private static Color lighter_chartreuse = Convert255(210,255,165);
		private static Color lighter_green = Convert255(165,255,165);
		private static Color lighter_sea = Convert255(165,255,210);
		private static Color lighter_turquoise = Convert255(165,255,232);
		private static Color lighter_cyan = Convert255(165,255,255);
		private static Color lighter_sky = Convert255(165,232,255);
		private static Color lighter_azure = Convert255(165,210,255);
		private static Color lighter_blue = Convert255(165,165,255);
		private static Color lighter_han = Convert255(188,165,255);
		private static Color lighter_violet = Convert255(210,165,255);
		private static Color lighter_purple = Convert255(232,165,255);
		private static Color lighter_fuchsia = Convert255(255,165,255);
		private static Color lighter_magenta = Convert255(255,165,232);
		private static Color lighter_pink = Convert255(255,165,210);
		private static Color lighter_crimson = Convert255(255,165,188);

		// Lightest colors
		private static Color lightest_red = Convert255(255,191,191);
		private static Color lightest_flame = Convert255(255,207,191);
		private static Color lightest_orange = Convert255(255,223,191);
		private static Color lightest_amber = Convert255(255,239,191);
		private static Color lightest_yellow = Convert255(255,255,191);
		private static Color lightest_lime = Convert255(239,255,191);
		private static Color lightest_chartreuse = Convert255(223,255,191);
		private static Color lightest_green = Convert255(191,255,191);
		private static Color lightest_sea = Convert255(191,255,223);
		private static Color lightest_turquoise = Convert255(191,255,239);
		private static Color lightest_cyan = Convert255(191,255,255);
		private static Color lightest_sky = Convert255(191,239,255);
		private static Color lightest_azure = Convert255(191,223,255);
		private static Color lightest_blue = Convert255(191,191,255);
		private static Color lightest_han = Convert255(207,191,255);
		private static Color lightest_violet = Convert255(223,191,255);
		private static Color lightest_purple = Convert255(239,191,255);
		private static Color lightest_fuchsia = Convert255(255,191,255);
		private static Color lightest_magenta = Convert255(255,191,239);
		private static Color lightest_pink = Convert255(255,191,223);
		private static Color lightest_crimson = Convert255(255,191,207);

		// Desaturated colors
		private static Color desaturated_red = Convert255(127,63,63);
		private static Color desaturated_flame = Convert255(127,79,63);
		private static Color desaturated_orange = Convert255(127,95,63);
		private static Color desaturated_amber = Convert255(127,111,63);
		private static Color desaturated_yellow = Convert255(127,127,63);
		private static Color desaturated_lime = Convert255(111,127,63);
		private static Color desaturated_chartreuse = Convert255(95,127,63);
		private static Color desaturated_green = Convert255(63,127,63);
		private static Color desaturated_sea = Convert255(63,127,95);
		private static Color desaturated_turquoise = Convert255(63,127,111);
		private static Color desaturated_cyan = Convert255(63,127,127);
		private static Color desaturated_sky = Convert255(63,111,127);
		private static Color desaturated_azure = Convert255(63,95,127);
		private static Color desaturated_blue = Convert255(63,63,127);
		private static Color desaturated_han = Convert255(79,63,127);
		private static Color desaturated_violet = Convert255(95,63,127);
		private static Color desaturated_purple = Convert255(111,63,127);
		private static Color desaturated_fuchsia = Convert255(127,63,127);
		private static Color desaturated_magenta = Convert255(127,63,111);
		private static Color desaturated_pink = Convert255(127,63,95);
		private static Color desaturated_crimson = Convert255(127,63,79);

		// Metallic
		private static Color brass = Convert255(191,151,96);
		private static Color copper = Convert255(197,136,124);
		private static Color gold = Convert255(229,191,0);
		private static Color silver = Convert255(203,203,203);

		// Miscellaneous
		private static Color celadon = Convert255(172,255,175);
		private static Color peach = Convert255(255,159,127);
        #endregion

        /// <summary>
        /// Converts a color from 0-255 to 0-1
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
		/// Converts a color from 0-255 to 0-1
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

        /// <summary>
        /// Gets a color from a property name in CustomColor
        /// </summary>
        /// <param name="uObject">The CustomColor object to pull the property from</param>
        /// <param name="propertyName">The name of the property/color to return</param>
        /// <returns></returns>
        public static Color ColorFromProperty(CustomColor uObject, string propertyName)
        {
            PropertyInfo property = typeof(CustomColor).GetProperty(propertyName, typeof(Color));
            Color color = black;
            if (property != null)
            {
                color = (Color)(property.GetValue(uObject, null));
            }
            else
            {
                Debug.LogError("There is no property named " + propertyName + " in CustomColor. Returning Black by default.");
                color =  black;
            }
            return color;
        }

        #region C# Properties
        // Default colors
        // Grey levels
        public static Color Black { get { return black; } }
        public Color Darkest_Grey {  get { return darkest_grey; } }
        public Color Darker_Grey { get { return darker_grey; } }
        public Color Dark_Grey { get { return dark_grey; } }
        public Color Grey { get { return grey; } }
        public Color Light_Grey { get { return light_grey; } }
        public Color Lighter_Grey { get { return lighter_grey; } }
        public Color Lightest_Grey { get { return lightest_grey; } }
        public Color Darkest_Gray { get { return darkest_gray; } }
        public Color Darker_Gray { get { return darker_gray; } }
        public Color Dark_Gray { get { return dark_gray; } }
        public Color Gray { get { return gray; } }
        public Color Light_Gray { get { return light_gray; } }
        public Color Lighter_Gray { get { return lighter_gray; } }
        public Color Lightest_Gray { get { return lightest_gray; } }
        public Color White { get { return white; } }

        // Sepia
        public Color Darkest_Sepia { get { return darkest_sepia; } }
        public Color Darker_Sepia { get { return darker_sepia; } }
        public Color Dark_Sepia { get { return dark_sepia; } }
        public Color Sepia { get { return sepia; } }
        public Color Light_Sepia { get { return light_sepia; } }
        public Color Lighter_Sepia { get { return lighter_sepia; } }
        public Color Lightest_Sepia { get { return lightest_sepia; } }

        // Standard colors
        public Color Red { get { return red; } }
        public Color Flame { get { return flame; } }
        public Color Orange { get { return orange; } }
        public Color Amber { get { return amber; } }
        public Color Yellow { get { return yellow; } }
        public Color Lime { get { return lime; } }
        public Color Chartreuse { get { return chartreuse; } }
        public Color Green { get { return green; } }
        public Color Sea { get { return sea; } }
        public Color Turquoise { get { return turquoise; } }
        public Color Cyan { get { return cyan; } }
        public Color Sky { get { return sky; } }
        public Color Azure { get { return azure; } }
        public Color Blue { get { return blue; } }
        public Color Han { get { return han; } }
        public Color Violet { get { return violet; } }
        public Color Purple { get { return purple; } }
        public Color Fuchsia { get { return fuchsia; } }
        public Color Magenta { get { return magenta; } }
        public Color Pink { get { return pink; } }
        public Color Crimson { get { return crimson; } }

        // Dark colors
        public Color Dark_Red { get { return dark_red; } }
        public Color Dark_Flame { get { return dark_flame; } }
        public Color Dark_Orange { get { return dark_orange; } }
        public Color Dark_Amber { get { return dark_amber; } }
        public Color Dark_Yellow { get { return dark_yellow; } }
        public Color Dark_Lime { get { return dark_lime; } }
        public Color Dark_Chartreuse { get { return dark_chartreuse; } }
        public Color Dark_Green { get { return dark_green; } }
        public Color Dark_Sea { get { return dark_sea; } }
        public Color Dark_Turquoise { get { return dark_turquoise; } }
        public Color Dark_Cyan { get { return dark_cyan; } }
        public Color Dark_Sky { get { return dark_sky; } }
        public Color Dark_Azure { get { return dark_azure; } }
        public Color Dark_Blue { get { return dark_blue; } }
        public Color Dark_Han { get { return dark_han; } }
        public Color Dark_Violet { get { return dark_violet; } }
        public Color Dark_Purple { get { return dark_purple; } }
        public Color Dark_Fuchsia { get { return dark_fuchsia; } }
        public Color Dark_Magenta { get { return dark_magenta; } }
        public Color Dark_Pink { get { return dark_pink; } }
        public Color Dark_Crimson { get { return dark_crimson; } }

        // Darker colors
        public Color Darker_Red { get { return darker_red; } }
        public Color Darker_Flame { get { return darker_flame; } }
        public Color Darker_Orange { get { return darker_orange; } }
        public Color Darker_Amber { get { return darker_amber; } }
        public Color Darker_Yellow { get { return darker_yellow; } }
        public Color Darker_Lime { get { return darker_lime; } }
        public Color Darker_Chartreuse { get { return darker_chartreuse; } }
        public Color Darker_Green { get { return darker_green; } }
        public Color Darker_Sea { get { return darker_sea; } }
        public Color Darker_Turquoise { get { return darker_turquoise; } }
        public Color Darker_Cyan { get { return darker_cyan; } }
        public Color Darker_Sky { get { return darker_sky; } }
        public Color Darker_Azure { get { return darker_azure; } }
        public Color Darker_Blue { get { return darker_blue; } }
        public Color Darker_Han { get { return darker_han; } }
        public Color Darker_Violet { get { return darker_violet; } }
        public Color Darker_Purple { get { return darker_purple; } }
        public Color Darker_Fuchsia { get { return darker_fuchsia; } }
        public Color Darker_Magenta { get { return darker_magenta; } }
        public Color Darker_Pink { get { return darker_pink; } }
        public Color Darker_Crimson { get { return darker_crimson; } }

        // Darkest colors
        public Color Darkest_Red { get { return darkest_red; } }
        public Color Darkest_Flame { get { return darkest_flame; } }
        public Color Darkest_Orange { get { return darkest_orange; } }
        public Color Darkest_Amber { get { return darkest_amber; } }
        public Color Darkest_Yellow { get { return darkest_yellow; } }
        public Color Darkest_Lime { get { return darkest_lime; } }
        public Color Darkest_Chartreuse { get { return darkest_chartreuse; } }
        public Color Darkest_Green { get { return darkest_green; } }
        public Color Darkest_Sea { get { return darkest_sea; } }
        public Color Darkest_Turquoise { get { return darkest_turquoise; } }
        public Color Darkest_Cyan { get { return darkest_cyan; } }
        public Color Darkest_Sky { get { return darkest_sky; } }
        public Color Darkest_Azure { get { return darkest_azure; } }
        public Color Darkest_Blue { get { return darkest_blue; } }
        public Color Darkest_Han { get { return darkest_han; } }
        public Color Darkest_Violet { get { return darkest_violet; } }
        public Color Darkest_Purple { get { return darkest_purple; } }
        public Color Darkest_Fuchsia { get { return darkest_fuchsia; } }
        public Color Darkest_Magenta { get { return darkest_magenta; } }
        public Color Darkest_Pink { get { return darkest_pink; } }
        public Color Darkest_Crimson { get { return darkest_crimson; } }

        // Light colors
        public Color Light_Red { get { return light_red; } }
        public Color Light_Flame { get { return light_flame; } }
        public Color Light_Orange { get { return light_orange; } }
        public Color Light_Amber { get { return light_amber; } }
        public Color Light_Yellow { get { return light_yellow; } }
        public Color Light_Lime { get { return light_lime; } }
        public Color Light_Chartreuse { get { return light_chartreuse; } }
        public Color Light_Green { get { return light_green; } }
        public Color Light_Sea { get { return light_sea; } }
        public Color Light_Turquoise { get { return light_turquoise; } }
        public Color Light_Cyan { get { return light_cyan; } }
        public Color Light_Sky { get { return light_sky; } }
        public Color Light_Azure { get { return light_azure; } }
        public Color Light_Blue { get { return light_blue; } }
        public Color Light_Han { get { return light_han; } }
        public Color Light_Violet { get { return light_violet; } }
        public Color Light_Purple { get { return light_purple; } }
        public Color Light_Fuchsia { get { return light_fuchsia; } }
        public Color Light_Magenta { get { return light_magenta; } }
        public Color Light_Pink { get { return light_pink; } }
        public Color Light_Crimson { get { return light_crimson; } }

        //Lighter colors
        public Color Lighter_Red { get { return lighter_red; } }
        public Color Lighter_Flame { get { return lighter_flame; } }
        public Color Lighter_Orange { get { return lighter_orange; } }
        public Color Lighter_Amber { get { return lighter_amber; } }
        public Color Lighter_Yellow { get { return lighter_yellow; } }
        public Color Lighter_Lime { get { return lighter_lime; } }
        public Color Lighter_Chartreuse { get { return lighter_chartreuse; } }
        public Color Lighter_Green { get { return lighter_green; } }
        public Color Lighter_Sea { get { return lighter_sea; } }
        public Color Lighter_Turquoise { get { return lighter_turquoise; } }
        public Color Lighter_Cyan { get { return lighter_cyan; } }
        public Color Lighter_Sky { get { return lighter_sky; } }
        public Color Lighter_Azure { get { return lighter_azure; } }
        public Color Lighter_Blue { get { return lighter_blue; } }
        public Color Lighter_Han { get { return lighter_han; } }
        public Color Lighter_Violet { get { return lighter_violet; } }
        public Color Lighter_Purple { get { return lighter_purple; } }
        public Color Lighter_Fuchsia { get { return lighter_fuchsia; } }
        public Color Lighter_Magenta { get { return lighter_magenta; } }
        public Color Lighter_Pink { get { return lighter_pink; } }
        public Color Lighter_Crimson { get { return lighter_crimson; } }

        // Lightest colors
        public Color Lightest_Red { get { return lightest_red; } }
        public Color Lightest_Flame { get { return lightest_flame; } }
        public Color Lightest_Orange { get { return lightest_orange; } }
        public Color Lightest_Amber { get { return lightest_amber; } }
        public Color Lightest_Yellow { get { return lightest_yellow; } }
        public Color Lightest_Lime { get { return lightest_lime; } }
        public Color Lightest_Chartreuse { get { return lightest_chartreuse; } }
        public Color Lightest_Green { get { return lightest_green; } }
        public Color Lightest_Sea { get { return lightest_sea; } }
        public Color Lightest_Turquoise { get { return lightest_turquoise; } }
        public Color Lightest_Cyan { get { return lightest_cyan; } }
        public Color Lightest_Sky { get { return lightest_sky; } }
        public Color Lightest_Azure { get { return lightest_azure; } }
        public Color Lightest_Blue { get { return lightest_blue; } }
        public Color Lightest_Han { get { return lightest_han; } }
        public Color Lightest_Violet { get { return lightest_violet; } }
        public Color Lightest_Purple { get { return lightest_purple; } }
        public Color Lightest_Fuchsia { get { return lightest_fuchsia; } }
        public Color Lightest_Magenta { get { return lightest_magenta; } }
        public Color Lightest_Pink { get { return lightest_pink; } }
        public Color Lightest_Crimson { get { return lightest_crimson; } }

        // Desaturated colors
        public Color Desaturated_Red { get { return desaturated_red; } }
        public Color Desaturated_Flame { get { return desaturated_flame; } }
        public Color Desaturated_Orange { get { return desaturated_orange; } }
        public Color Desaturated_Amber { get { return desaturated_amber; } }
        public Color Desaturated_Yellow { get { return desaturated_yellow; } }
        public Color Desaturated_Lime { get { return desaturated_lime; } }
        public Color Desaturated_Chartreuse { get { return desaturated_chartreuse; } }
        public Color Desaturated_Green { get { return desaturated_green; } }
        public Color Desaturated_Sea { get { return desaturated_sea; } }
        public Color Desaturated_Turquoise { get { return desaturated_turquoise; } }
        public Color Desaturated_Cyan { get { return desaturated_cyan; } }
        public Color Desaturated_Sky { get { return desaturated_sky; } }
        public Color Desaturated_Azure { get { return desaturated_azure; } }
        public Color Desaturated_Blue { get { return desaturated_blue; } }
        public Color Desaturated_Han { get { return desaturated_han; } }
        public Color Desaturated_Violet { get { return desaturated_violet; } }
        public Color Desaturated_Purple { get { return desaturated_purple; } }
        public Color Desaturated_Fuchsia { get { return desaturated_fuchsia; } }
        public Color Desaturated_Magenta { get { return desaturated_magenta; } }
        public Color Desaturated_Pink { get { return desaturated_pink; } }
        public Color Desaturated_Crimson { get { return desaturated_crimson; } }

        // metallic
        public Color Brass { get { return brass; } }
        public Color Copper { get { return copper; } }
        public Color Gold { get { return gold; } }
        public Color Silver { get { return silver; } }

        // miscellaneous
        public Color Celadon { get { return celadon; } }
        public Color Peach { get { return peach; } }
        #endregion
    }
}