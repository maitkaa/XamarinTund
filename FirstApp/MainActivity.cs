using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace FirstApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        
        protected double result;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            //Result
            var textview = FindViewById<TextView>(Resource.Id.textView1);
            //Userinput 1 and 2 In EditText XML must be android:inputType="numberDecimal" 
            var textfield1 = FindViewById<EditText>(Resource.Id.editText1);
            var textfield2 = FindViewById<EditText>(Resource.Id.editText2);
            //Calculate and Clear buttons
            var button = FindViewById<Button>(Resource.Id.button1);
            var button2 = FindViewById<Button>(Resource.Id.button2);

                button.Click += delegate
                {
                    var inputtext = textfield1.Text.ToString();

                    var inputtext2 = textfield2.Text.ToString();

                    result = Convert.ToDouble(inputtext) + Convert.ToDouble(inputtext2);

                    textview.Text = "Result is " + result.ToString();

                };
            
           // Clear textfields and restore Textview original value
            button2.Click += delegate
            {
                textfield1.Text = "";
                textfield2.Text = "";
                textview.Text = "Super Calculator";

            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

      
    }
}