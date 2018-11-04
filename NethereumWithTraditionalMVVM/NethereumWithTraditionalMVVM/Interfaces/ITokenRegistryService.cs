using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NethereumWithTraditionalMVVM.Model;

namespace NethereumWithTraditionalMVVM.Interfaces
{
    public interface ITokenRegistryService
    {
        List<ContractToken> GetRegisteredTokens();
        Task RegisterToken(ContractToken token);
    }
}
