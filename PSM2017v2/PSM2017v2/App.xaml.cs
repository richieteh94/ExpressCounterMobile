﻿using PSM2017v2.Database;
using PSM2017v2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace PSM2017v2
{
    public partial class App : Application
    {
        static ProductDatabase productDB;
        public App ()
        {
            InitializeComponent();

            //MainPage = new PSM2017v2.MainPage();
            MainPage = new NavigationPage(new ScanPage());
        }

        public static ProductDatabase Database
        {
            get
            {
                if (productDB == null)
                {
                    productDB = new ProductDatabase(DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("Cart.db3"));
                }
                return productDB;
            }
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }

    }
}
