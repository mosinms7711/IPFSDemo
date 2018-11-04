using System;
using System.Collections.Generic;
using System.Diagnostics;
using NethereumWithTraditionalMVVM.Interfaces;
using NethereumWithTraditionalMVVM.Model;
using Xamarin.Forms;

namespace NethereumWithTraditionalMVVM
{
    public partial class DashboardPage : MasterDetailPage
    {
        public IFileEngine fileEngine = DependencyService.Get<IFileEngine>();

        public DashboardPage()
        {
            InitializeComponent();

            Debug.WriteLine("dashboard initialize");

            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        protected override void OnAppearing()
        {
            NavigationPage.SetBackButtonTitle(this, string.Empty);
            NavigationPage.SetHasBackButton(this, false);
        }
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailPageModel;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}
