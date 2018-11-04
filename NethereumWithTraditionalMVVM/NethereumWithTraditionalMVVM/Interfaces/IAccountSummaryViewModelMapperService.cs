using System;
using System.Collections.Generic;
using NethereumWithTraditionalMVVM.Model;
using NethereumWithTraditionalMVVM.ViewModel;

namespace NethereumWithTraditionalMVVM.Interfaces
{
    public interface IAccountSummaryViewModelMapperService
    {
        List<AccountSummaryViewModel> Map(List<AccountInfo> accountsInfo);
    }
}
