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
    public partial class RestockPage : ContentPage
    {
        ObservableCollection<Product> productFromNextPage;

        public RestockPage(ObservableCollection<Product> products2)
        {
            InitializeComponent();
            productFromNextPage = products2;
            BindingContext = productFromNextPage;
            myrestock.ItemsSource = productFromNextPage;

        }



        private void myrestock_itemselected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Restock_Clicked(object sender, EventArgs e)
        {

            if ((myrestock.SelectedItem as Product == null) || (updatedQuantity.Text == " "))
            {
                DisplayAlert("Error", "You have to select an item and provide a new quantity", "OK");
                updatedQuantity.Text = " ";
            }
            else
            {
                int newQ = (myrestock.SelectedItem as Product).Quantity + int.Parse(updatedQuantity.Text);
                double newP = (myrestock.SelectedItem as Product).Price;
                string newN = (myrestock.SelectedItem as Product).Name;
                int index = productFromNextPage.IndexOf((myrestock.SelectedItem as Product));

                productFromNextPage.Remove(myrestock.SelectedItem as Product);

                productFromNextPage.Insert(index, new Product(newN, newQ, newP));
                updatedQuantity.Text = " ";
            }

        }
    }
}