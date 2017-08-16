using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Acr.UserDialogs;
using Xamarin.Forms;
using PayPal.Forms;
using PayPal.Forms.Abstractions;
using PayPal.Forms.Abstractions.Enum;
using Android.Content;

namespace PSM2017v2.Droid
{
	[Activity (Label = "PSM2017v2", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            UserDialogs.Init(() => (Activity)Forms.Context);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            //global::ZXing.Net.Mobile.Forms.Android.Platform.Init();

            CrossPayPalManager.Init(
                new PayPalConfiguration(
                    PayPalEnvironment.NoNetwork,
                    "this_is_your_paypal_key"
                )
                {
                    AcceptCreditCards = true,
                    MerchantName = "PSM2017v2",
                    MerchantPrivacyPolicyUri = "https://www.example.com/privacy",
                    MerchantUserAgreementUri = "https://www.example.com/legal"
                }
            );

            LoadApplication(new PSM2017v2.App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            PayPalManagerImplementation.Manager.OnActivityResult(requestCode, resultCode, data);
        }

        protected override void OnDestroy()
        {
            PayPalManagerImplementation.Manager.Destroy();
            base.OnDestroy();
            
        }
    }
}

