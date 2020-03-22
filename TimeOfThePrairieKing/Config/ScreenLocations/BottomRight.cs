namespace TimeOfThePrairieKingMod.Config.ScreenLocations
{
    /// <summary>
    /// User configuration for drawing the time in the bottom right corner
    /// </summary>
    public class BottomRight
    {
        /// <summary>
        /// Whether or not to draw the time in the bottom right corner (defaults false)
        /// </summary>
        public bool Show { get; set; } = true;

        /// <summary>
        /// The color to draw the time in
        /// </summary>
        public string HexColor { get; set; } = "#808080";
    }
}
