using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using NethereumWithTraditionalMVVM.Interfaces;
using NethereumWithTraditionalMVVM.Model;
using NethereumWithTraditionalMVVM.Services;
using Xamarin.Forms;

namespace NethereumWithTraditionalMVVM.ViewModel
{
    public class BalancePageViewModel:BaseViewModel
    {
        //private readonly IEthWalletService walletService;
        EthWalletService walletService = new EthWalletService();

        // private readonly IAccountTokenViewModelMapperService accountTokenViewModelMapperService;
        AccountTokenViewModelMapperService accountTokenViewModelMapperService = new AccountTokenViewModelMapperService();

        public BalancePageViewModel()
        {
            tokenBalanceSummary = new ObservableCollection<AccountTokenViewModel>();
            Title = "Balances";
            Icon = "blog.png";
        }

        private AccountTokenViewModel selectedToken;
        private ObservableCollection<AccountTokenViewModel> tokenBalanceSummary;

        public ObservableCollection<AccountTokenViewModel> TokensBalanceSummary
        {
            get { return tokenBalanceSummary; }
            set
            {
                tokenBalanceSummary = value;
                NotifyPropertyChanged("TokensBalanceSummary");
            }
        }



        public AccountTokenViewModel SelectedToken
        {
            get { return selectedToken; }
            set
            {
                selectedToken = value;
                NotifyPropertyChanged("SelectedToken");
            }
        }

        /* public ICommand LoadItemsCommand
         {
             get { return new ICommand(LoadData()); }
         }

         public ICommand RefreshItemsCommand
         {
             get { return new MvxAsyncCommand(() => LoadData(true)); }
         }

         public override async void Start()
         {
             if (TokensBalanceSummary == null || TokensBalanceSummary.Count == 0)
             {
                 await LoadData();
             }

             base.Start();
         }*/


        public async Task LoadData(bool forceRefresh = false)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            var error = false;
            try
            {
                var walletSummary = await walletService.GetWalletSummary(forceRefresh);
                TokensBalanceSummary.Clear();
                foreach (var accountSummary in accountTokenViewModelMapperService.Map(walletSummary.EthBalanceSummary,
                walletSummary.TokenBalanceSummary))
                {
                    TokensBalanceSummary.Add(accountSummary);
                }
            }
            catch
            {
                error = true;
            }

            if (error)
            {
                var page = new ContentPage();
                await page.DisplayAlert("Error", "Unable to load token summary", "OK");
            }

            IsBusy = false;
        }
    }
}
