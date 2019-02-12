using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Xamarin_Android_Auto_Test.BroadcastReceivers;
using static Android.App.Notification;

namespace Xamarin_Android_Auto_Test.Notifications
{
    public static class Notifications
    {
        private static Intent GetMessageReadIntent(int id)
        {
            return new Intent().SetAction(Class.FromType(typeof(MyMessageReadReceiver)).Name)
                    .PutExtra("conversation_id", id);
        }

        // Creates an Intent that will be triggered when a voice reply is received.
        private static Intent GetMessageReplyIntent(int conversationId)
        {
            return new Intent().SetAction(Class.FromType(typeof(MyMessageReplyReceiver)).Name)
                    .PutExtra("conversation_id", conversationId);
        }

        public static void ShowNotification(Context context) {
            Android.Util.Log.Info("Xamarin", "Sending notification to Android & Android Auto!");

            PendingIntent readPendingIntent = PendingIntent.GetBroadcast(context,
                123, GetMessageReadIntent(123), PendingIntentFlags.UpdateCurrent);

            Android.Support.V4.App.RemoteInput remoteInput = new Android.Support.V4.App.RemoteInput.Builder("extra_voice_reply")
                    .SetLabel("carnotification")
                    .Build();

            PendingIntent replyIntent = PendingIntent.GetBroadcast(context,
                    123,
                    GetMessageReplyIntent(123),
                    PendingIntentFlags.UpdateCurrent);

            NotificationCompat.CarExtender.UnreadConversation.Builder unreadConversationBuilder =
               new NotificationCompat.CarExtender.UnreadConversation.Builder("Hello Android Auto From Xamarin")
               .SetLatestTimestamp(JavaSystem.CurrentTimeMillis())
               .SetReadPendingIntent(readPendingIntent)
               .SetReplyAction(replyIntent, remoteInput);

            unreadConversationBuilder.AddMessage("This is the body for android auto.");

            var builder = new NotificationCompat.Builder(context, "MyChannel")
                              .SetAutoCancel(true) // Dismiss the notification from the notification area when the user clicks on it
                              .SetContentTitle("Hello Android From Xamarin") // Set the title
                              .SetSmallIcon(Resource.Drawable.design_ic_visibility)
                              .SetContentText($"This is the body for android device.")
                              .Extend(new NotificationCompat.CarExtender()
                                            .SetUnreadConversation(
                                                unreadConversationBuilder.Build()
                                            )
                                  );

            // Finally, publish the notification:
            var notificationManager = NotificationManagerCompat.From(context);
            notificationManager.Notify(123456, builder.Build());
        }
    }
}