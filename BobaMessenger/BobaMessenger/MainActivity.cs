using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using BobaMessenger.Utility.PlayServices;
using BobaMessenger.Models.PlayServices.Enum;
using Android.Util;
using BobaMessenger.Services.FirebaseService;
using Firebase.Iid;

namespace BobaMessenger
{
    [Activity(Label = "BobaMessenger", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            //https://developer.xamarin.com/guides/android/application_fundamentals/notifications/remote-notifications-with-fcm/
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug("MainActivity", "Key: {0} Value: {1}", key, value);
                }
            }

            var playServicesHelper = new PlayServicesHelper(this);

            switch (playServicesHelper.IsPlayServicesAvailable())
            {
                case PlayServiceStatus.Available:
                    break;
                case PlayServiceStatus.Unavailable:
                    //User Resolvable
                    break;
                case PlayServiceStatus.Shutdown:
                    Finish();
                    break;
                default:
                    throw new Exception("PlayServiceStatus was unknown");                
            }


            button.Click += delegate { button.Text = FirebaseInstanceId.Instance.Token; };
        }
    }
}

