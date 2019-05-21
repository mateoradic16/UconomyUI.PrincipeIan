using Rocket.Unturned;
using Rocket.Core.Plugins;
using SDG.Unturned;
using Rocket.Unturned.Player;
using System.Collections.Generic;
using Steamworks;
using fr34kyn01535.Uconomy;

namespace UconomyUI.By.PrincipeIan
{
    public class UconomyUI : RocketPlugin<UconomyUIConfig>
    {
        public static UconomyUI Instance;
        Dictionary<CSteamID, decimal> dicionaa = new Dictionary<CSteamID, decimal>();

        protected override void Load()
        {
        Instance = this;
        Rocket.Core.Logging.Logger.Log("Plugin loaded correctly");
        Rocket.Core.Logging.Logger.Log("UconomyUI free By PrincipeIan(Edited By Teo)");
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
            Uconomy.Instance.OnBalanceUpdate += Instance_OnBalanceUpdate;
            U.Events.OnPlayerDisconnected += Events_OnPlayerDisconnected;
        }
        private void Events_OnPlayerDisconnected(UnturnedPlayer player) {

            dicionaa.Remove(player.CSteamID);
            EffectManager.askEffectClearByID(45321, player.CSteamID);
        }
        private void Instance_OnBalanceUpdate(UnturnedPlayer player, decimal amt)
        {
            dicionaa[player.CSteamID] = Uconomy.Instance.Database.GetBalance(player.CSteamID.ToString());
            EffectManager.askEffectClearByID(45321, player.CSteamID);
            EffectManager.sendUIEffect(45321, 3221, player.CSteamID, true, Configuration.Instance.colorBalance, "$" + dicionaa[player.CSteamID].ToString());
        }
        private void Events_OnPlayerConnected(UnturnedPlayer player)
        {         
            
            dicionaa.Add(player.CSteamID, Uconomy.Instance.Database.GetBalance(player.CSteamID.ToString()));
            EffectManager.sendUIEffect(45321, 3221, player.CSteamID, true ,Uconomy.Instance.Configuration.Instance.MoneyName+dicionaa[player.CSteamID].ToString());
        }
        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
            Uconomy.Instance.OnBalanceUpdate -= Instance_OnBalanceUpdate;
            U.Events.OnPlayerDisconnected -= Events_OnPlayerDisconnected;
        }
    }
}
