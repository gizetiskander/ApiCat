using ApiCat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiCat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatViewPage : ContentPage
    {
        public CatViewPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.CountManager.GetTasksAsync();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateCatPage(true)
            {
                BindingContext = new CatModel()
                {
                    id = Guid.NewGuid().ToString(),
                }
            });
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new CreateCatPage()
            {
                BindingContext = e.SelectedItem as CatModel
            });
        }
    }
}