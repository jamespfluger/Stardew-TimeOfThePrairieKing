﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeOfThePrairieKingMod.Config.ScreenLocations
{
    /// <summary>
    /// User configuration for drawing the time on the minigame's HUD
    /// </summary>
    public class MinigameHud
    {
        /// <summary>
        /// Whether or not to draw the time on the minigame's HUD (defaults true)
        /// </summary>
        public bool Show { get; set; } = false;

        /// <summary>
        /// The color to draw the time in
        /// </summary>
        public string HexColor { get; set; } = "#CD853F";
    }
}
