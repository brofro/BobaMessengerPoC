using Android.App;
using Android.Content;
using Android.Gms.Common;
using BobaMessenger.Models.PlayServices.Enum;

namespace BobaMessenger.Utility.PlayServices
{
    public class PlayServicesHelper
    {
        private Context MainContext { get; set; }

        public PlayServicesHelper(Context context)
        {
            MainContext = context;
        }

                
        public PlayServiceStatus IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(MainContext);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    //msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                }

                else
                {
                    //msgText.Text = "This device is not supported";     
                    return PlayServiceStatus.Shutdown;               
                }
                return PlayServiceStatus.Unavailable;
            }
            else
            {
                //msgText.Text = "Google Play Services is available.";
                return PlayServiceStatus.Available;
            }
        }
    }
}