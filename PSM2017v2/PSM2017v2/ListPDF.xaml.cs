using PCLStorage;
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
	public partial class ListPDF : ContentPage
	{
		public ListPDF ()
		{
			InitializeComponent ();
		}

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selection = e.SelectedItem as IFile;
                Task.Run(() =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PushAsync(new WebViewPageCS(selection.Path));
                    });
                });
                #region DisableSelectedHighlighting
                ((ListView)sender).SelectedItem = null;
                #endregion
            }


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                IFolder folder = FileSystem.Current.LocalStorage;
                String folderName = "receipt";
                ExistenceCheckResult exist = await folder.CheckExistsAsync(folderName);

                //String filename = "username.txt";
                //IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

                if (exist == ExistenceCheckResult.FolderExists)
                {
                    //await DisplayAlert("Alert",folderName+" is exist","OK");
                    IList<IFile> files = await folder.GetFilesAsync();
                    //await DisplayAlert("Alert", files.Count + " number of files", "OK");
                    pdfListView.ItemsSource = files;

                }

            });
        }

        private void OnDelete(object sender, EventArgs e)
        {
            var selected = (MenuItem)sender;
            var selectedFile = selected.CommandParameter as IFile;
            Device.BeginInvokeOnMainThread(async () =>
            {
                bool answer = await DisplayAlert("Delete File", "Do you want to delete " + selectedFile.Name +" ?", "Yes", "No");
                if (answer)
                {
                    IFolder folder = FileSystem.Current.LocalStorage;
                    String folderName = "receipt";
                    ExistenceCheckResult exist = await folder.CheckExistsAsync(folderName);

                    if (exist == ExistenceCheckResult.FolderExists)
                    {
                        IFile file = await folder.GetFileAsync(selectedFile.Name);

                        //	Act
                        await file.DeleteAsync();

                        IList<IFile> files = await folder.GetFilesAsync();
                        pdfListView.ItemsSource = files;

                    }

                    
                }
            });
            
        }
    }
}
