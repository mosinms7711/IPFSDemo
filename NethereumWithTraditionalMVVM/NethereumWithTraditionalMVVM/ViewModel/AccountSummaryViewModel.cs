using System;
namespace NethereumWithTraditionalMVVM.ViewModel
{
    public class AccountSummaryViewModel : BaseViewModel
    {
        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                NotifyPropertyChanged("Address");
                ImgUrl = AddressToGravatar.GetImgUrl(address);
            }
        }

        private string imgUrl;
        public string ImgUrl
        {
            get { return imgUrl; }
            set 
            {
                imgUrl = value;
                NotifyPropertyChanged("ImgUrl"); 
            }
        }

        private string balanceSummary;
        public string BalanceSummary
        {
            get { return balanceSummary; }
            set 
            {
                balanceSummary = value;
                NotifyPropertyChanged("BalanceSummary"); 
            }
        }

    }
}
