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
using Newtonsoft.Json;

namespace AppGeolocalizador.Entity
{
    public class Geolocalizador
    {
        [JsonProperty("geonames")]
        public IList<test> geonames { get; set; }


        public class test
        {
            [JsonProperty("continent")]
            public string continent { get; set; }

            [JsonProperty("capital")]
            public string capital { get; set; }

            [JsonProperty("languages")]
            public string languages { get; set; }

            [JsonProperty("geonameId")]
            public string geonameId { get; set; }

            [JsonProperty("south")]
            public string south { get; set; }

            [JsonProperty("isoAlpha3")]
            public string isoAlpha3 { get; set; }

            [JsonProperty("north")]
            public string north { get; set; }

            [JsonProperty("fipsCode")]
            public string fipsCode { get; set; }

            [JsonProperty("population")]
            public string population { get; set; }

            [JsonProperty("east")]
            public string east { get; set; }
            [JsonProperty("isoNumeric")]
            public string isoNumeric { get; set; }
            [JsonProperty("areaInSqKm")]
            public string areaInSqKm { get; set; }
            [JsonProperty("countryCode")]
            public string countryCode { get; set; }
            [JsonProperty("west")]
            public string west { get; set; }
            [JsonProperty("countryName")]
            public string countryName { get; set; }
            [JsonProperty("continentName")]
            public string continentName { get; set; }
            [JsonProperty("currencyCode")]
            public string currencyCode { get; set; }
        }

        public class Account
        {
            public string github;
        }

    }
}