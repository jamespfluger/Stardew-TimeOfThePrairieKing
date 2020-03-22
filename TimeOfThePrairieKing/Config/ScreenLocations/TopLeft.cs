﻿namespace TimeOfThePrairieKingMod.Config.ScreenLocations
{
    /// <summary>
    /// User configuration for drawing the time in the top left corner
    /// </summary>
    public class TopLeft
    {
        /// <summary>
        /// Whether or not to draw the time in the top left corner
        /// </summary>
        public bool Show { get; set; } = false;

        /// <summary>
        /// The color to draw the time in
        /// </summary>
        public string HexColor { get; set; } = "#808080";
    }
}
