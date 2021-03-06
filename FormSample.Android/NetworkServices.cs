using FormSample.Droid;
using Xamarin.Forms;
using Android.App;
using Android.Net;

[assembly: Dependency(typeof(NetworkService))]
namespace FormSample.Droid
{
    public class NetworkService : INetworkService
    {
        private ConnectivityManager connectivityManager;
        public NetworkService()
        {
            this.connectivityManager = (ConnectivityManager)Forms.Context.GetSystemService(Application.ConnectivityService);
        }

        public bool IsReachable()
        {
            var isConnected = false;

            var activeConnection = this.connectivityManager.ActiveNetworkInfo;

            if ((activeConnection != null) && activeConnection.IsConnected)
            {
                isConnected = true;
            }

            var mobile = this.connectivityManager.GetNetworkInfo(ConnectivityType.Mobile).GetState();
            if (mobile == NetworkInfo.State.Connected)
            {
                // We are connected via WiFi
                isConnected = true;
            }

            var wifiState = this.connectivityManager.GetNetworkInfo(ConnectivityType.Wifi).GetState();
            if (wifiState == NetworkInfo.State.Connected)
            {
                isConnected = true;
            }

            return isConnected;
        }
    }
}