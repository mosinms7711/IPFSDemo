using System;
using System.Collections.Generic;
using System.Diagnostics;
using NethereumWithTraditionalMVVM.ViewModel;
using Xamarin.Forms;

namespace NethereumWithTraditionalMVVM
{
    public partial class AccountSummary : ContentPage
    {
        public AccountSummary()
        {
            InitializeComponent();

            var vm = new AccountBalanceSummaryViewModel();
            this.BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var vm = BindingContext as AccountBalanceSummaryViewModel;
                await vm.LoadData(false);
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
