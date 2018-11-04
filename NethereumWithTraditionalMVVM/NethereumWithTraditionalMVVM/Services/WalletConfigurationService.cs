using System;
using Nethereum.Web3;

namespace NethereumWithTraditionalMVVM.Services
{
    public class WalletConfigurationService : IWalletConfigurationService
    {
        //public string ClientUrl { get; set; } = "http://159.65.80.74:8991/";
        public string ClientUrl { get; set; } = "https://rinkeby.infura.io/";


        public Web3 GetReadOnlyWeb3()
        {
            return new Web3(ClientUrl);
        }

        public bool IsConfigured()
        {
            return !string.IsNullOrEmpty(ClientUrl);
        }

    }
}
