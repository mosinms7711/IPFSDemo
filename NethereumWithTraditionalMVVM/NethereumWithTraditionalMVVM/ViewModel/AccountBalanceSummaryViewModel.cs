using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using NethereumWithTraditionalMVVM.Model;
using NethereumWithTraditionalMVVM.Services;
using Xamarin.Forms;

namespace NethereumWithTraditionalMVVM.ViewModel
{
    public class AccountBalanceSummaryViewModel : BaseViewModel
    {
        // private readonly IAccountSummaryViewModelMapperService accountSummaryViewModelMapperService;
        //private readonly IMvxNavigationService _navigationService;
        //private readonly IEthWalletService walletService;

        AccountSummaryViewModelMapperService accountSummaryViewModelMapperService = new AccountSummaryViewModelMapperService();
        EthWalletService walletService = new EthWalletService();


        public AccountBalanceSummaryViewModel()
        {
            AccountsSummary = new ObservableCollection<AccountSummaryViewModel>();
            Title = "Accounts";
            Icon = "blog.png";
        }

        private ObservableCollection<AccountSummaryViewModel> accountsSummary;
        public ObservableCollection<AccountSummaryViewModel> AccountsSummary
        {
            get { return accountsSummary; }
            set
            {
                accountsSummary = value;
                NotifyPropertyChanged("AccountsSummary");
            }
        }

        public async Task LoadData(bool forceRefresh = false)
        {
            try
            {
                Debug.WriteLine("try");
                if (IsBusy)
                    return;

                IsBusy = true;
                var error = false;
                try
                {
                    Debug.WriteLine(" Second try");
                    var walletSummary = await walletService.GetWalletSummary(forceRefresh);
                    AccountsSummary.Clear();
                    Debug.WriteLine("clear account summary");
                    foreach (var accountSummary in accountSummaryViewModelMapperService.Map(walletSummary.AccountsInfo))
                    {
                        AccountsSummary.Add(accountSummary);
                        Debug.WriteLine("inside foreach accountsummary");
                    }
                }
                catch
                {
                    error = true;
                }

                if (error)
                {
                    var page = new ContentPage();
                    await page.DisplayAlert("Error", "Unable to load accounts", "OK");
                }

                IsBusy = false;
            }
            catch(Exception err)
            {
                Debug.WriteLine("Message:" + err.Message);
                Debug.WriteLine("Stack Trace:" + err.StackTrace);
                Debug.WriteLine("Source:" + err.Source);
            }
        }
    }
}
