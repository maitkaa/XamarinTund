using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.first_layout1);

            var textview = FindViewById<TextView>(Resource.Id.textView1);
            var textfield1 = FindViewById<EditText>(Resource.Id.editText1);
            var textfield2 = FindViewById<EditText>(Resource.Id.editText1);
            var button = FindViewById<Button>(Resource.Id.button1);

            //double a = Convert.ToDouble(textfield1);
            //double b = Convert.ToDouble(textfield2);
            var arv1 = int.Parse(textfield1.Text);
            var arv2 = int.Parse(textfield2.Text);
            var result = 0;


            button.Click += delegate
            {

                result = arv1 + arv2;
                textview.Text = "result = "+result;
                
            };
        }
    }
}