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

namespace Xamarin_Android_Auto_Test.BroadcastReceivers
{
    [BroadcastReceiver]
    public class MyMessageReplyReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Android.Util.Log.Info("Xamarin", "Android Auto Reply Receiver!");
        }
    }
}