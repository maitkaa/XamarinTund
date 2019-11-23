using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Xamarin.Essentials;
using System;
using System.Threading.Tasks;

namespace ThirdApp
{
    [Activity(Label = "Third App", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Button button1 = FindViewById<Button>(Resource.Id.button1);

            button1.Click += (sender, e) => {
                float chargeLevel = (float)Battery.ChargeLevel * 100;
                var chargeLevelValue = chargeLevel.ToString();
                chargeLevelValue += '%';
                var textview = FindViewById<TextView>(Resource.Id.textView1);
                textview.Text = chargeLevelValue;
            };
           
            ToggleButton togglebutton = FindViewById<ToggleButton>(Resource.Id.toggleButton1);
            togglebutton.Click += (o, e) => {
                // Perform action on clicks
                if (togglebutton.Checked)
                    Flashlight.TurnOnAsync();
                else
                    Flashlight.TurnOffAsync();
            };
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += (sender, e) => {

                SpeakNow("Hello World");

            };
           
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public async Task SpeakNow(string text)
        {
            
            var settings = new SpeechOptions()
            {
              
                Pitch = 0.1f
            };
            
            await TextToSpeech.SpeakAsync(text, settings);
        }
       
    }
    

}