using System;
using System.Collections.Generic;
using System.Diagnostics;
using NethereumWithTraditionalMVVM.ViewModel;
using Xamarin.Forms;

namespace NethereumWithTraditionalMVVM
{
    public partial class BalancePage : ContentPage
    {
        public BalancePage()
        {
            InitializeComponent();

            var vm = new BalancePageViewModel();
            this.BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var vm = BindingContext as BalancePageViewModel;
                await vm.LoadData(false);
            }
            catch(Exception err)
            {
                Debug.WriteLine("Message:"+err.Message);
                Debug.WriteLine("Source:" + err.Source);
                Debug.WriteLine("Stack Trace:" + err.StackTrace);
            }
        }
    }
}
