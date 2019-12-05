using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Collections.Generic;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Android.Content;

namespace FourthApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
           
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var listView = FindViewById<ListView>(Resource.Id.listView1);

            var carList = new List<Car>
            {
            new Car(){Manufactor="Tesla", Model="CyberTruck",KW=300, Image=Resource.Drawable.tesla},
            new Car(){Manufactor="Tesla", Model="X",KW=25,Image=Resource.Drawable.tesla1},
            new Car(){Manufactor="Tesla", Model="W",KW=125},
            new Car(){Manufactor="Tesla", Model="E",KW=250},
            new Car(){Manufactor="Tesla", Model="S",KW=10},
            new Car(){Manufactor="Tesla", Model="T",KW=123},
            new Car(){Manufactor="Fiat", Model="jura",KW=300},
            new Car(){Manufactor="Ford", Model="MitteFocus",KW=300,Image=Resource.Drawable.tesla2},
            new Car(){Manufactor="Hyndai", Model="Tänak",KW=1000},
            new Car(){Manufactor="Ford", Model="T",KW=100},
            new Car(){Manufactor="Lada", Model="1",KW=300},
            new Car(){Manufactor="Subaru", Model="Impressive",KW=530},

            };
            
            
   
            listView.Adapter = new basicAdapter(this, carList);

            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                var position = args.Position;
                var imageResource = carList[position].Image;

                var intent = new Intent(this, typeof(ImageActivity));
                intent.PutExtra("imageResource", imageResource);
                StartActivity(intent);
                //Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Short).Show();
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}