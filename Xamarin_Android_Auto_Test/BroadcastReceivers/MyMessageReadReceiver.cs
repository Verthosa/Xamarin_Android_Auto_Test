using Android.Content;
using Android.Support.V4.App;
using Android.Widget;

namespace Xamarin_Android_Auto_Test.BroadcastReceivers
{
    [BroadcastReceiver]
    public class MyMessageReadReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Android.Util.Log.Info("Xamarin", "Android Auto Read Receiver!");

            int conversationId = intent.GetIntExtra("conversation_id", -1);

            if (conversationId != -1)
            {
                NotificationManagerCompat.From(context).Cancel(conversationId);
            }

        }
    }
}