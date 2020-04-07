using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Minigames;
using TimeOfThePrairieKingMod.Config;
using TimeOfThePrairieKingMod.Utils;

namespace TimeOfThePrairieKingMod
{
    public class TimeOfThePrairieKing : Mod
    {
        /// <summary>
        /// User configuration set in the mod
        /// </summary>
        public static UserConfig Config { get; private set; }

        /// <summary>
        /// Stardew Valley modding API
        /// </summary>
        public static IModHelper SMAPI { get; private set; }

        /// <summary>
        /// SMAPI provided API for logging
        /// </summary>
        public static IMonitor Logger { get; private set; }

        /// <summary>
        /// Whether or not the rendered event has been added already
        /// </summary>
        private bool hasAddedRenderListener = false;

        public override void Entry(IModHelper helper)
        {
            TimeOfThePrairieKing.Config = helper.ReadConfig<UserConfig>();

            if (!TimeOfThePrairieKing.Config.Enabled)
                return;

            SMAPI = helper;
            Logger = Monitor;

            Helper.Events.GameLoop.TimeChanged += OnTimeChangedHandler;
        }

        /// <summary>
        /// For performance reasons, only check if the game time has changed
        /// </summary>
        private void OnTimeChangedHandler(object sender, TimeChangedEventArgs args)
        {
            if (Context.IsMultiplayer && Game1.currentMinigame is AbigailGame)
            {
                if (!hasAddedRenderListener)
                {
                    Logger.Log("Adding the rendered handler");
                    Helper.Events.Display.Rendered += OnRenderedHandler;
                    hasAddedRenderListener = true;
                }
            }
            else
            {
                Helper.Events.Display.Rendered -= OnRenderedHandler;
                hasAddedRenderListener = false;
            }
        }

        /// <summary>
        /// Render the time if all of the conditions have been met (we should be in the minigame at this point)
        /// </summary>
        private void OnRenderedHandler(object sender, RenderedEventArgs args)
        {
            if (Game1.currentMinigame is AbigailGame && !AbigailGame.onStartMenu && Game1.getOnlineFarmers().Count>1)
            {
                TimeDrawUtil.DrawTime(args.SpriteBatch);
            }
        }
    }
}
