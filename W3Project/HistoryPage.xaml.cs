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
    public partial class HistoryPage : ContentPage
    {

        ObservableCollection<History> historyFromNextPage;

        public HistoryPage(ObservableCollection<History> histories1)
        {
            InitializeComponent();
            historyFromNextPage = histories1;
            BindingContext = historyFromNextPage;
            myhistory.ItemsSource = historyFromNextPage;
        }


        async void myhistroy_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            History h = e.SelectedItem as History;
            await Navigation.PushAsync(new HistoryPageDetail(h));
        }
    }
}
