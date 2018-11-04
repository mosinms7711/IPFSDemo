using System;
using Nethereum.Web3;

namespace NethereumWithTraditionalMVVM.Services
{
    public interface IWalletConfigurationService
    {
        string ClientUrl { get; set; }
        bool IsConfigured();
        Web3 GetReadOnlyWeb3();
    }
}
