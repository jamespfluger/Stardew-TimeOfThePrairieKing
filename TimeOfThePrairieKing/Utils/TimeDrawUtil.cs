using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Minigames;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TimeOfThePrairieKingMod.Config;

namespace TimeOfThePrairieKingMod.Utils
{
    /// <summary>
    /// Utility to draw the in-game time on the screen
    /// </summary>
    public static class TimeDrawUtil
    {
        /// <summary>
        /// User configuration set in the mod
        /// </summary>
        public static UserConfig Config { get; set; }

        /// <summary>
        /// Possible screen corners to draw the time at
        /// </summary>
        public enum ScreenCorner
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight
        }

        /// <summary>
        /// Draws the in-game time at a configured location on the screen
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw on</param>
        public static void DrawTime(SpriteBatch spriteBatch)
        {
            try
            {
                if (Config.MinigameHud.Show)
                {
                    Vector2 hudDestination = DestinationUtil.GetHudDestination();
                    Color timeColor = GetColorFromHex(Config.MinigameHud.HexColor);
                    DrawTimeAtDestination(spriteBatch, hudDestination, timeColor);
                }

                if (Config.TopLeft.Show)
                    DrawTimeInCorner(spriteBatch, ScreenCorner.TopLeft, Config.TopLeft.HexColor);
                if (Config.TopRight.Show)
                    DrawTimeInCorner(spriteBatch, ScreenCorner.TopRight, Config.TopRight.HexColor);
                if (Config.BottomLeft.Show)
                    DrawTimeInCorner(spriteBatch, ScreenCorner.BottomLeft, Config.BottomLeft.HexColor);
                if (Config.BottomRight.Show)
                    DrawTimeInCorner(spriteBatch, ScreenCorner.BottomRight, Config.BottomRight.HexColor);

            }
            catch (Exception e)
            {
                TimeOfThePrairieKing.Logger.Log("Error drawing time:" + e.ToString());
            }
        }

        /// <summary>
        /// Draws the time in a given destination
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw on</param>
        /// <param name="destination">Location to draw the time in</param>
        /// <param name="color">Color of the font to use</param>
        private static void DrawTimeAtDestination(SpriteBatch spriteBatch, Vector2 destination, Color color)
        {
            spriteBatch.DrawString(spriteFont: Game1.smallFont,
                                   text: Game1.getTimeOfDayString(Game1.timeOfDay),
                                   position: destination,
                                   color: color);
        }

        /// <summary>
        /// Draws the time in a given corner
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw on</param>
        /// <param name="corner">Corner of screen to draw in</param>
        /// <param name="color">Color of the font to use</param>
        private static void DrawTimeInCorner(SpriteBatch spriteBatch, ScreenCorner corner, string color)
        {
            Vector2 destination = DestinationUtil.GetCornerDestination(corner);
            Color timeColor = GetColorFromHex(color);

            DrawTimeAtDestination(spriteBatch, destination, timeColor);
        }

        /// <summary>
        /// Converts a hex color string into an XNA Framework Color object
        /// </summary>
        /// <param name="hexColor">String of a hex color</param>
        /// <returns>A new Color object</returns>
        private static Color GetColorFromHex(string hexColor)
        {
            Regex hexValidator = new Regex("^#?(?:[0-9a-fA-F]{3}){2}$");

            if (!hexValidator.IsMatch(hexColor))
                return Color.Gray;

            if (hexColor.StartsWith("#"))
                hexColor = hexColor.Substring(1);


            int r = int.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            int g = int.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            int b = int.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);

            return new Color(r, g, b);
        }
    }
}
