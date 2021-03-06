using Android.App;
using Android.Util;
using Firebase.Iid;

namespace BobaMessenger.Services.FirebaseService
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class FirebaseIdService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";

        public string InstanceTokenId { get; set; }

        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "Refreshed token: " + refreshedToken);
            SendRegistrationToServer(refreshedToken);
        }

        void SendRegistrationToServer(string token)
        {
            // Add custom implementation, as needed.
        }        
    }
}