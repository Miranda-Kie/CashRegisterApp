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
    public partial class NewProductPage : ContentPage
    {
        ObservableCollection<Product> productFromNextPage;
        public NewProductPage(ObservableCollection<Product> product3)
        {
            InitializeComponent();
            productFromNextPage = product3;
        }

        async void SaveClicked(object sender, EventArgs e)
        {

            int newQ = Convert.ToInt32(newProductQ.Text);
            double newP = Convert.ToDouble(newProductP.Text);
            string newN = newProductN.Text;

            productFromNextPage.Add(new Product() { Name = newN, Price = newP, Quantity = newQ });
            await Navigation.PopAsync();
            await DisplayAlert("Done!", "New Product Added successfully", "OK");
          
        }

        async void CancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}