using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PSM2017v2.Helper;
using System.IO;
using PSM2017v2.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileHelperAndroid))]
namespace PSM2017v2.Droid
{
    public class LocalFileHelperAndroid : ILocalFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }
    }
}