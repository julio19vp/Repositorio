using Android.App;
using Android.Widget;
using Android.OS;
using Plugin.Geolocator;
using AppGeolocalizador.Entity;

namespace AppGeolocalizador
{
    [Activity(Label = "AppGeolocalizador", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var labelGPS = FindViewById<TextView>(Resource.Id.labelGPS);
            var contryCode = FindViewById<TextView>(Resource.Id.contryCode);
            var contryInfo = FindViewById<TextView>(Resource.Id.ContryInfo);

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

            if (position == null)
            {
                labelGPS.Text = "null gps :(";
                return;
            }
            labelGPS.Text = string.Format("Time: {0} \nLat: {1} \nLong: {2} \n Altitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \n Heading: {6} \n Speed: {7}",
            position.Timestamp, position.Latitude, position.Longitude,
            position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);

            string ContryCode;
            Geolocalizador geo = new Geolocalizador();
            using (var Client = new System.Net.Http.HttpClient())
            {
                var URLWebAPIContryCode = "http://api.geonames.org/countryCode?lat=" + position.Latitude + "&lng=" + position.Longitude + "&username=julio19vp";
                ContryCode = await Client.GetStringAsync(URLWebAPIContryCode);
            }
            using (var Client2 = new System.Net.Http.HttpClient()) {
                var URLWebAPIContryInfo = "http://api.geonames.org/countryInfoJSON?lang=es&country=" + ContryCode.Trim() + "&username=julio19vp";
                var ContryInfo = await Client2.GetStringAsync(URLWebAPIContryInfo);
                geo = Newtonsoft.Json.JsonConvert.DeserializeObject<Geolocalizador>(ContryInfo);
            }
            contryCode.Text = ContryCode.Trim();
            contryInfo.Text = $"{geo.geonames[0].continent}\n{geo.geonames[0].capital}\n{geo.geonames[0].languages}\n{geo.geonames[0].geonameId}\n{geo.geonames[0].south}\n{geo.geonames[0].isoAlpha3}\n{geo.geonames[0].north}\n{geo.geonames[0].fipsCode}\n{geo.geonames[0].population} \n{geo.geonames[0].east} \n{geo.geonames[0].isoNumeric} \n{geo.geonames[0].areaInSqKm} \n{geo.geonames[0].countryCode}\n{geo.geonames[0].west}\n{geo.geonames[0].countryName}\n{geo.geonames[0].currencyCode} ";

        }
    }
}

