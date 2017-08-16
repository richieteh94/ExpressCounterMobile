using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PSM2017v2.Helper
{
    static class XFToast
    {
        public static void ShortMessage(string message)
        {
            DependencyService.Get<IMessage>().ShortAlert(message);
        }

        public static void LongMessage(string message)
        {
            DependencyService.Get<IMessage>().LongAlert(message);
        }
    }
}
