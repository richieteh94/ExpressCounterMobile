using Acr.UserDialogs;
using Newtonsoft.Json;
using PayPal.Forms;
using PayPal.Forms.Abstractions;
using PayPal.Forms.Abstractions.Enum;
using PCLStorage;
using PSM2017v2.Helper;
using PSM2017v2.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace PSM2017v2
{
	public class ScanPage : ContentPage
	{
        ZXingScannerView zxings;
        ZXingDefaultOverlay defaultOverlay;

        public string localHostUrl = "http://192.168.43.54:8080/PSM2017/";
        //public string localHostUrl = "http://192.168.0.174:8080/PSM2017/";

        public ScanPage()
        {
            zxings = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingScannerView",
                IsScanning=true
            };

            zxings.OnScanResult += (result) =>
                Device.BeginInvokeOnMainThread(async () =>
                {
                    zxings.IsAnalyzing = false;
                    string barcode = result.Text;

                    if (App.Database.GetProducts().Count < 10)
                    {
                        string data = "";
                        string postData = "barcode=" + barcode;
                        string url = localHostUrl + "dbGetProduct.php";
                        WebService searchProduct = new WebService();
                        data = searchProduct.postService(postData, url);
                        if (data.Contains("{"))
                        {
                            Product product = JsonConvert.DeserializeObject<Product>(data);
                            //Product product = products.Find(x => x.barcode == Int32.Parse(barcode));
                            App.Database.AddProduct(product);
                            await DisplayAlert("Item Added", product.name + " added into list.", "OK");
                        }
                        else
                        {
                            XFToast.LongMessage(data);
                        }
                    }
                    else
                    {
                        await DisplayAlert("Alert!", "Your cart has 10 items. The cart could only hold up to 10 items. " +
                            "Please pay for the item(s) or delete item!!!", "OK");
                    }

                    // Stop analysis until we navigate away so we don't keep reading barcodes
                    zxings.IsAnalyzing = true;
                    // Show an alert
                    //await DisplayAlert("Scanned Barcode", result.Text, "OK");

                    // Navigate away
                    //await Navigation.PopAsync();
                });

            var scanOverlay = new RelativeLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            Xamarin.Forms.Label text = new Xamarin.Forms.Label
            {
                Text = "Hold your phone up to the barcode",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White
            };
            Xamarin.Forms.Label text2 = new Xamarin.Forms.Label
            {
                Text = "Scanning will happen automatically",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White
            };

            BoxView redLine = new BoxView
            {
                BackgroundColor = Color.Red,
                Opacity = 0.6
            };
            BoxView boxView = new BoxView
            {
                BackgroundColor = Color.Black,
                Opacity = 0.7
            };
            BoxView boxView2 = new BoxView
            {
                BackgroundColor = Color.Black,
                Opacity = 0.7
            };
            BoxView boxView3 = new BoxView
            {
                BackgroundColor = Color.Black,
                Opacity = 0.7
            };
            BoxView boxView4 = new BoxView
            {
                BackgroundColor = Color.Black,
                Opacity = 0.7
            };
            scanOverlay.Children.Add(boxView, 
                Constraint.RelativeToParent((parent) =>{
                    return parent.X;
                }),
                Constraint.RelativeToParent((parent) => {
                    return parent.Y;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width*0.1;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height;
                })
            );
            scanOverlay.Children.Add(boxView2,
                Constraint.RelativeToParent((parent) => {
                    return parent.Width * 0.9;
                }),
                Constraint.RelativeToParent((parent) => {
                    return parent.Y;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * 0.1;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height;
                })
            );
            scanOverlay.Children.Add(boxView3,
                Constraint.RelativeToParent((parent) => {
                    return parent.Width*0.1;
                }),
                Constraint.RelativeToParent((parent) => {
                    return parent.Y;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width*0.8;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * 0.2;
                })
            );
            scanOverlay.Children.Add(boxView4,
                Constraint.RelativeToParent((parent) => {
                    return parent.Width*0.1;
                }),
                Constraint.RelativeToParent((parent) => {
                    return parent.Height * 0.6;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width*0.8;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * 0.4;
                })
            );
            scanOverlay.Children.Add(redLine,
                Constraint.RelativeToParent((parent) => {
                    return parent.Width * 0.1;
                }),
                Constraint.RelativeToParent((parent) => {
                    return parent.Height * 0.4;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * 0.8;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return 3;
                })
            );
            scanOverlay.Children.Add(text,
                Constraint.RelativeToParent((parent)=>
                {
                    return parent.Width * 0.2;
                }),
                Constraint.RelativeToParent((parent) => 
                {
                    return parent.Height * 0.1;
                })
            );
            scanOverlay.Children.Add(text2,
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * 0.2;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * 0.8;
                })
            );


            defaultOverlay = new ZXingDefaultOverlay
            {
                TopText = "Hold your phone up to the barcode",
                BottomText = "Scanning will happen automatically",
                //ShowFlashButton = true,
                AutomationId = "zxingDefaultOverlay",
            };
            defaultOverlay.BindingContext = defaultOverlay;

            var customOverlay = new RelativeLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var torchFAB = new FAB.Forms.FloatingActionButton();
            torchFAB.Source = "flashlight_icon.png";
            torchFAB.NormalColor = Color.FromHex("FFE066");
            torchFAB.Size = FAB.Forms.FabSize.Normal;
            torchFAB.Clicked += (sender, args) =>
            {
                zxings.ToggleTorch();
            };

            var listFAB = new FAB.Forms.FloatingActionButton();
            listFAB.Source = "shoping_cart.png";
            listFAB.NormalColor = Color.FromHex("FFE066");
            listFAB.Size = FAB.Forms.FabSize.Normal;
            listFAB.Clicked += async(sender, args) =>
            {
                //zxing.IsAnalyzing = false;
                //XFToast.LongMessage("Hello");
                await Navigation.PushAsync(new ListViewProduct());
     
            };

            var addFAB = new FAB.Forms.FloatingActionButton();
            addFAB.Source = "plus_black_symbol.png";
            addFAB.NormalColor = Color.FromHex("FFE066");
            addFAB.Size = FAB.Forms.FabSize.Normal;
            addFAB.Clicked += async (sender, args) =>
            {
                if (App.Database.GetProducts().Count < 10)
                {
                    var config = new PromptConfig();
                    config.Title = "Manual enter product barcode";
                    config.InputType = InputType.Number;
                    config.OnAction = async (result) =>
                    {
                        if (result.Ok)
                        {
                            string barcode = result.Text;
                            string postData = "barcode=" + barcode;
                            string url = localHostUrl + "dbGetProduct.php";
                            WebService searchProduct = new WebService();
                            string data = searchProduct.postService(postData, url);

                            if (data.Contains("{"))
                            {
                                Product product = JsonConvert.DeserializeObject<Product>(data);
                                //Product product = products.Find(x => x.barcode == Int32.Parse(barcode));
                                App.Database.AddProduct(product);
                                await DisplayAlert("Item Added", product.name + " added into list.", "OK");     
                            }
                            else
                            {
                                XFToast.LongMessage(data);
                            }
                        }
                        zxings.IsAnalyzing = true;
                    };
                    await Task.Run(() =>
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            zxings.IsAnalyzing = false;
                            UserDialogs.Instance.Prompt(config);
                        });
                    });
                }
                else
                {
                    await DisplayAlert("Alert!", "Your cart has 10 items.The cart could only hold up to 10 items. " +
                        "Please pay for the item(s) or delete item!!!", "OK");
                }
                //App.Database.AddProduct(new Product {Name = "Milo", Price = 20.587, Barcode = 00001 });
            };

            var checkOutFAB = new FAB.Forms.FloatingActionButton();
            checkOutFAB.Source = "cash_register_machine.png";
            checkOutFAB.NormalColor = Color.FromHex("FFE066");
            checkOutFAB.Size = FAB.Forms.FabSize.Normal;
            checkOutFAB.Clicked += (sender, args) =>
            {
                //XFToast.LongMessage("Check out");
                var products = App.Database.GetProducts();

                if (products.Count > 0)
                {
                    Task.Run(async () => {
                        PayPalItem[] paypalItems = new PayPalItem[products.Count];
                        int i = 0;


                        foreach (Product product in products)
                        {

                            PayPalItem paypalItem = new PayPalItem(product.name, 1, Convert.ToDecimal(product.price), "MYR"
                                , product.barcode);
                            paypalItems[i] = paypalItem;
                            i++;
                        }

                        var result = await CrossPayPalManager.Current.Buy(paypalItems, new Decimal(0.0), new Decimal(0.00));
                        if (result.Status == PayPalStatus.Cancelled)
                        {
                            Debug.WriteLine("Cancelled");
                        }
                        else if (result.Status == PayPalStatus.Error)
                        {
                            Debug.WriteLine(result.ErrorMessage);
                        }
                        else if (result.Status == PayPalStatus.Successful)
                        {
                            Debug.WriteLine(result.ServerResponse.Response.Id);

                            var jsonArray = JsonConvert.SerializeObject(products);

                            string jsnArray = jsonArray.ToString();
                            string postData = "receipt=" + jsnArray;
                            string url = localHostUrl + "genReceipt.php";
                            WebService searchProduct = new WebService();
                            string data = searchProduct.postService(postData, url);
                            if (data.ToLower().Contains(".pdf"))
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    await DisplayAlert("Payment Success", "The payment is success!!", "OK");
                                    App.Database.ClearList();
                                    downloadPDF(data);
                                    await DisplayAlert("Download Success", "Receipt downloaded", "OK");

                                });
                            }
                        }
                    });
                }
                else
                {
                    DisplayAlert("Alert!", "There are no item in the cart list.", "OK");
                }

                  
            };

            var receiptFAB = new FAB.Forms.FloatingActionButton();
            receiptFAB.Source = "receiptIcon";
            receiptFAB.NormalColor = Color.FromHex("FFE066");
            receiptFAB.Size = FAB.Forms.FabSize.Normal;
            receiptFAB.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new ListPDF());
            };
            /*
            customOverlay.Children.Add(
                torchFAB,
                xConstraint: Constraint.RelativeToParent((parent) => { return parent.Width - 48; }),
                yConstraint: Constraint.RelativeToParent((parent) => { return 8; })
            );

            customOverlay.Children.Add(
                listFAB,
                Constraint.RelativeToView(torchFAB, (Parent, sibling) => { return sibling.X; }),
                Constraint.RelativeToView(torchFAB, (Parent, sibling) => { return sibling.Y + 48; })
            );
            customOverlay.Children.Add(
                addFAB,
                Constraint.RelativeToView(listFAB, (Parent, sibling) => { return sibling.X; }),
                Constraint.RelativeToView(listFAB, (Parent, sibling) => { return sibling.Y + 48; })
            );
            customOverlay.Children.Add(
                checkOutFAB,
                Constraint.RelativeToView(addFAB, (Parent, sibling) => { return sibling.X; }),
                Constraint.RelativeToView(addFAB, (Parent, sibling) => { return sibling.Y + 48; })
            );
            customOverlay.Children.Add(
                receiptFAB,
                Constraint.RelativeToView(checkOutFAB, (Parent, sibling) => { return sibling.X; }),
                Constraint.RelativeToView(checkOutFAB, (Parent, sibling) => { return sibling.Y + 48; })
            );
            */

            customOverlay.Children.Add(
                torchFAB,
                xConstraint: Constraint.RelativeToParent((parent) => { return parent.X + 6; }),
                yConstraint: Constraint.RelativeToParent((parent) => { return parent.Height * 0.6 + 24; })
            );

            customOverlay.Children.Add(
                listFAB,
                Constraint.RelativeToView(torchFAB, (Parent, sibling) => { return sibling.X + 72; }),
                Constraint.RelativeToView(torchFAB, (Parent, sibling) => { return sibling.Y; })
            );
            customOverlay.Children.Add(
                addFAB,
                Constraint.RelativeToView(listFAB, (Parent, sibling) => { return sibling.X + 72; }),
                Constraint.RelativeToView(listFAB, (Parent, sibling) => { return sibling.Y; })
            );
            customOverlay.Children.Add(
                checkOutFAB,
                Constraint.RelativeToView(addFAB, (Parent, sibling) => { return sibling.X + 72; }),
                Constraint.RelativeToView(addFAB, (Parent, sibling) => { return sibling.Y; })
            );
            customOverlay.Children.Add(
                receiptFAB,
                Constraint.RelativeToView(checkOutFAB, (Parent, sibling) => { return sibling.X + 72; }),
                Constraint.RelativeToView(checkOutFAB, (Parent, sibling) => { return sibling.Y; })
            );


            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            grid.Children.Add(zxings);
            //grid.Children.Add(defaultOverlay);
            grid.Children.Add(scanOverlay);
            grid.Children.Add(customOverlay);
            

            Content = grid;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            zxings.IsAnalyzing = true;
        }

        protected override void OnDisappearing()
        {
            zxings.IsAnalyzing = false;
            base.OnDisappearing();
        }

        private void downloadPDF(string fileName)
        {
            var webClient = new WebClient();
            webClient.DownloadDataCompleted += async (s, e2) =>
            {
                var data = e2.Result;
                IFolder folder = FileSystem.Current.LocalStorage;
                String folderName = "receipt";
                ExistenceCheckResult exist = await folder.CheckExistsAsync(folderName);
                if (exist == ExistenceCheckResult.NotFound)
                {
                    folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.FailIfExists);
                }
                string localFilename = fileName;
                await folder.CreateFileAsync(localFilename, CreationCollisionOption.ReplaceExisting);
                IFile file = await folder.CreateFileAsync(localFilename, CreationCollisionOption.ReplaceExisting);

                using (Stream stream = await file.OpenAsync(PCLStorage.FileAccess.ReadAndWrite))
                {
                    stream.Write(data, 0, data.Length);
                }
                //File.WriteAllBytes(file.Path,data);
                //await DisplayAlert("Done", fileName+" download complete", "OK");
            };
            var url = new Uri(localHostUrl + "pdf/" +fileName);
            webClient.DownloadDataAsync(url);
        }
        
    }
}
