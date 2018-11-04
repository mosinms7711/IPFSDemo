using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NethereumWithTraditionalMVVM.Interfaces
{
    public interface IAccountRegistryService
    {
        List<string> Accounts { get; set; }

        List<string> GetDefaultAccounts();
        List<string> GetRegisteredAccounts();
        Task RegisterAccountAddress(string address);
    }
}
