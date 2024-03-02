using Playnite.SDK;
using Playnite.SDK.Events;
using Playnite.SDK.Models;
using Playnite.SDK.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DeezGames
{
    public class DeezGames : GenericPlugin
    {
        private static readonly ILogger logger = LogManager.GetLogger();

        private DeezGamesSettingsViewModel settings { get; set; }

        public override Guid Id { get; } = Guid.Parse("32c32b50-c9a9-44cd-bd5b-e7869d065ee7");

        public DeezGames(IPlayniteAPI api) : base(api)
        {
            settings = new DeezGamesSettingsViewModel(this);
            Properties = new GenericPluginProperties
            {
                HasSettings = true
            };
        }

        public override IEnumerable<GameMenuItem> GetGameMenuItems(GetGameMenuItemsArgs menuItemArgs)
        {
            yield return new GameMenuItem
            {
                Description = "Deez nuts-ify",
                Action = (args) =>
                {
                    foreach (Game game in args.Games)
                    {
                        game.Name = StringUtils.DeezNutsify(game.Name);
                        PlayniteApi.Database.Games.Update(game);
                    }
                    // use args.Games to get list of games attached to the menu source

                }
            };
        }

        public override void OnGameInstalled(OnGameInstalledEventArgs args)
        {
            // Add code to be executed when game is finished installing.
        }

        public override void OnGameStarted(OnGameStartedEventArgs args)
        {
            // Add code to be executed when game is started running.
        }

        public override void OnGameStarting(OnGameStartingEventArgs args)
        {
            // Add code to be executed when game is preparing to be started.
        }

        public override void OnGameStopped(OnGameStoppedEventArgs args)
        {
            // Add code to be executed when game is preparing to be started.
        }

        public override void OnGameUninstalled(OnGameUninstalledEventArgs args)
        {
            // Add code to be executed when game is uninstalled.
        }

        public override void OnApplicationStarted(OnApplicationStartedEventArgs args)
        {
            // Add code to be executed when Playnite is initialized.
        }

        public override void OnApplicationStopped(OnApplicationStoppedEventArgs args)
        {
            // Add code to be executed when Playnite is shutting down.
        }

        public override void OnLibraryUpdated(OnLibraryUpdatedEventArgs args)
        {
            // Add code to be executed when library is updated.
        }

        public override ISettings GetSettings(bool firstRunSettings)
        {
            return settings;
        }

        public override UserControl GetSettingsView(bool firstRunSettings)
        {
            return new DeezGamesSettingsView();
        }
    }
}