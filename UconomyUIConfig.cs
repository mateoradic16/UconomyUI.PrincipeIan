using Rocket.API;

namespace UconomyUI.By.PrincipeIan
{
    public class UconomyUIConfig : IRocketPluginConfiguration
    {
        public string colorBalance;
        public string serverName;
        public string currency;
        public void LoadDefaults()
        {
            colorBalance = "#06B409";
            serverName = "ServerName";
            currency = "#B43E06";
        }
    }
}