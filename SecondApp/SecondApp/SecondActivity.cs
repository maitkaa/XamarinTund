using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace SecondApp
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.second_layout);
            var text = Intent.GetStringExtra("edittextvalue");
            var textview = FindViewById<TextView>(Resource.Id.textView1);
            textview.Text = text;


            //XAMARIN ESSENTIALS

            var appName = AppInfo.Name;
            var packageName = AppInfo.PackageName;
            var version = AppInfo.Version;
            var build = AppInfo.BuildString;

            AppInfo.ShowSettingsUI();
            var duration = TimeSpan.FromSeconds(10);
            Vibration.Vibrate(duration);
            await NavigateToBuilding();

        }


        public async Task NavigateToBuilding()
        {
            var location = new Location(53.123334, -122.134333);
            var options = new MapLaunchOptions { Name= "Kodu" };
            await Map.OpenAsync(location, options);
        }

    }
}