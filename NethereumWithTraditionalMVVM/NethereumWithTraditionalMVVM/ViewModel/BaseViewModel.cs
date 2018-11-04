using System;
using NethereumWithTraditionalMVVM.Services;

namespace NethereumWithTraditionalMVVM.ViewModel
{
    public class BaseViewModel:PropertyNotifier
    {
        private string icon;
        private bool isBusy;
        private string title;

        public string Icon
        {
            get { return icon; }
            set
            {
                NotifyPropertyChanged("Icon");
            }
        }


        public string Title
        {
            get { return title; }
            set
            {
                NotifyPropertyChanged("Title");
            }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                NotifyPropertyChanged("IsBusy");
            }
        }
    }
}
