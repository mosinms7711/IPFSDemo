using System;
using NethereumWithTraditionalMVVM.ViewModel;

namespace NethereumWithTraditionalMVVM.Model
{
    public class AccountTokenViewModel : BaseViewModel
    {
        private string symbol;
        public string Symbol
        {
            get { return symbol; }
            set 
            {
                symbol = value;
                NotifyPropertyChanged("Symbol"); 
            }
        }

        private decimal balance;
        public decimal Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                NotifyPropertyChanged("Balance"); 
            }
        }

        private string tokenName;
        public string TokenName
        {
            get { return tokenName; }
            set
            {
                tokenName = value;
                NotifyPropertyChanged("TokenName");
            }
        }

        private string tokenImgUrl;
        public string TokenImgUrl
        {
            get { return tokenImgUrl; }
            set
            {
                tokenImgUrl = value;
                NotifyPropertyChanged("TokenImgUrl");
            }
        }

    }
}
