using System;
using System.Collections.Generic;
using NethereumWithTraditionalMVVM.Model;

namespace NethereumWithTraditionalMVVM.Interfaces
{
    public interface IAccountTokenViewModelMapperService
    {
        List<AccountTokenViewModel> Map(List<AccountToken> accountTokens);
        List<AccountTokenViewModel> Map(EthAccountToken ethAccountToken, List<AccountToken> accountTokens);
    }
}
