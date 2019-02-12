# Xamarin_Android_Auto_Test
Testing Xamarin capabilities for Android Auto - porting my native java code to Xamarin. 

Works like a charm. 

What i learned is that, as i thought it is mandatory to:

1) create and set an automotive_app_desc.xml and reference it from the manifest.xml
2) when creating a CarExtender.UnreadConversation you have to set the 
      SetLatestTimeStamp()
      SetReadPendingIntent()
      SetReplyAction()
      
# Screenshot
![alt text](https://github.com/Verthosa/Xamarin_Android_Auto_Test/blob/master/xamarin_android_auto.png)
