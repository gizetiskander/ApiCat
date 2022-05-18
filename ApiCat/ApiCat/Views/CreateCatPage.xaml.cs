using ApiCat.Model;
using ApiCat.Service;
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
    public partial class CreateCatPage : ContentPage
    {
        bool isNewItem;
        public CreateCatPage(bool isNew = false)
        {
            InitializeComponent();
            isNewItem = isNew;
        }

        private async void btn_Save_ClickedAsync(object sender, EventArgs e)
        {
            var Item = (CatModel)BindingContext;
            await App.CountManager.SaveItemAsync(Item, isNewItem);
            await Navigation.PopAsync();
        }

        private async void btn_Delete_Clicked(object sender, EventArgs e)
        {
            var Item = (CatModel)BindingContext;
            await App.CountManager.DeleteTodoAsync(Item);
            await Navigation.PopAsync();
        }
    }
}