using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using PayPal.Forms;
using PayPal.Forms.Abstractions;
using PayPal.Forms.Abstractions.Enum;

namespace PSM2017v2.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

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

            LoadApplication (new PSM2017v2.App ());

            ZXing.Net.Mobile.Forms.iOS.Platform.Init();
            return base.FinishedLaunching (app, options);
		}
	}
}
