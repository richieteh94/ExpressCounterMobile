using System;
using System.Collections.Generic;
using System.Text;

namespace PSM2017v2.Helper
{
    interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
