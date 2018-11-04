using System;
using System.Collections.ObjectModel;
using NethereumWithTraditionalMVVM.Model;

namespace NethereumWithTraditionalMVVM.ViewModel
{
    public class MenuPageViewModel : BaseViewModel
    {
        public ObservableCollection<MasterDetailPageModel> MenuItems { get; set; }

        public MenuPageViewModel()
        {

            MenuItems = new ObservableCollection<MasterDetailPageModel>(new[]
            {
                new MasterDetailPageModel { Id = 0,Icon = "ethIcon.png", Title = "Balance Summary", TargetType = typeof(BalancePage) },
                new MasterDetailPageModel { Id = 1,Icon = "blog.png", Title = "Accounts" , TargetType = typeof(AccountSummary) }
                });
        }
    }
}
