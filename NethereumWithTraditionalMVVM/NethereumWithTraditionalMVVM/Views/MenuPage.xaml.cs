using System;
using System.Collections.Generic;
using NethereumWithTraditionalMVVM.ViewModel;
using Xamarin.Forms;

namespace NethereumWithTraditionalMVVM
{
    public partial class MenuPage : ContentPage
    {
        public ListView ListView;
        
        public MenuPage()
        {
            InitializeComponent();

            ListView = MenuItemsListView;

            var vm = new MenuPageViewModel();
            this.BindingContext = vm;
        }
    }
}
