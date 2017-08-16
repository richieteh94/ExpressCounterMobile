using PSM2017v2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PSM2017v2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewProduct : ContentPage
	{
		public ListViewProduct ()
		{
			InitializeComponent ();
		}

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selection = e.SelectedItem as Product;
                //DisplayAlert("You selected", selection.Name, "OK");
                bool answer = await DisplayAlert("Delete Item", "Do you want to delete " + selection.name + " from list?", "Yes", "No");
                if (answer)
                {
                    App.Database.DeleteProduct(selection);
                    listView.ItemsSource = App.Database.GetProducts();
                }

                #region DisableSelectedHighlighting
                ((ListView)sender).SelectedItem = null;
                #endregion
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(() =>
            {
                listView.ItemsSource = App.Database.GetProducts();
            });
        }
    }
}
