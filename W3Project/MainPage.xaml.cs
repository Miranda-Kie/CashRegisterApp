using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace W3Project
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Product> products = new ObservableCollection<Product>();
        ObservableCollection<History> histories = new ObservableCollection<History>();


        public MainPage()
        {
            InitializeComponent();


            products.Add(new Product() { Name = "Pants", Price = 20.10, Quantity = 100 });

            products.Add(new Product() { Name = "Shoes", Price = 50.40, Quantity = 50 });

            products.Add(new Product() { Name = "Hats", Price = 10.33, Quantity = 60 });

            products.Add(new Product() { Name = "Tshirts", Price = 10.00, Quantity = 70 });

            products.Add(new Product() { Name = "Dresses", Price = 24.05, Quantity = 20 });


            mylist.ItemsSource = products;
        }

        private void mylist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DisplayType.Text = (e.SelectedItem as Product).Name;
        }



        private void Number_Clicked(object sender, EventArgs e)
        {
            if (mylist.SelectedItem != null)
            {
                if (DisplayQuantity.Text == "Quantity")
                {
                    DisplayQuantity.Text = " ";
                    DisplayTotal.Text = " ";
                }

                Button btn = (Button)sender;
                int numQ = 0;
                double singlePrice = (mylist.SelectedItem as Product).Price;
                double sumS = 0.00;

  

                    if (btn.Text != "Buy")
                    {
                        DisplayQuantity.Text += btn.Text;
                        if (double.Parse(DisplayQuantity.Text) > (mylist.SelectedItem as Product).Quantity)
                        {
                            DisplayAlert("Quantity is larger than ", ((mylist.SelectedItem as Product).Quantity).ToString(), "ReEnter");
                            DisplayQuantity.Text = "Quantity";
                        }

                    }
                    else
                    {
                        if (DisplayQuantity.Text == " ")
                        {
                            DisplayAlert("Please select a quantity", "such as 3", "OK");
                        }
                        else
                        {
                            int newQ = (mylist.SelectedItem as Product).Quantity - Convert.ToInt32(DisplayQuantity.Text);
                        double newP = (mylist.SelectedItem as Product).Price;
                        string newN = (mylist.SelectedItem as Product).Name;
                        int index = products.IndexOf((mylist.SelectedItem as Product));

                        products.Remove(mylist.SelectedItem as Product);

                        products.Insert(index, new Product(newN, newQ, newP));

                        numQ = Convert.ToInt32(DisplayQuantity.Text);
                        sumS = numQ * singlePrice;

                        DisplayTotal.Text = Math.Round(sumS, 2).ToString("#.00");
                        DisplayType.Text = "Type";
                        DisplayQuantity.Text = "Quantity";
                        histories.Add(new History() { Name = (mylist.SelectedItem as Product).Name, Quantity = numQ, TotalPrice = sumS, Now = DateTime.Now });
                        }
                    }
                
            }
            else
            {
                DisplayAlert("Please select an item first", "such as Pants", "OK");
            } 
            
        }

        async void Manager_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NextPage(histories, products));
        }
    }
}