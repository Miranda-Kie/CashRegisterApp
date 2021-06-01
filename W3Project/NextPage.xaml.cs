using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace W3Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NextPage : ContentPage
    {


        ObservableCollection<History> historyFromFirstPage;
        ObservableCollection<Product> productFromFirstPage;
        public NextPage(ObservableCollection<History> histories1, ObservableCollection<Product> products1)
        {
            InitializeComponent();
            historyFromFirstPage = histories1;
            productFromFirstPage = products1;

        }


        async void History_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage(historyFromFirstPage));
        }

        async void Restock_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RestockPage(productFromFirstPage));
        }

        async void newProduct_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewProductPage(productFromFirstPage));
        }
    }
}