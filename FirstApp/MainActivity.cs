using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Xamarin.Essentials;
using Android.Graphics;

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
            var addBtn = FindViewById<Button>(Resource.Id.button3);
            var divideBtn = FindViewById<Button>(Resource.Id.button4);
            var subtractBtn = FindViewById<Button>(Resource.Id.button5);
            var multiplyBtn = FindViewById<Button>(Resource.Id.button6);
            var action = 0;
            

            addBtn.Click += delegate
            {
                action += 1;
                addBtn.SetBackgroundColor(Color.Red);
            };
            divideBtn.Click += delegate
            {
                action += 2;
                divideBtn.SetBackgroundColor(Color.Red);
            };
            multiplyBtn.Click += delegate
            {
                action += 3;
                multiplyBtn.SetBackgroundColor(Color.Red);
            };
            subtractBtn.Click += delegate
            {
                action += 4;
                subtractBtn.SetBackgroundColor(Color.Red); 
            };

            button.Click += delegate
                {
                    var inputtext = textfield1.Text.ToString();

                    var inputtext2 = textfield2.Text.ToString();

                    if (string.IsNullOrEmpty(inputtext))
                    {
                        inputtext = "0";
                    }
                    if (string.IsNullOrEmpty(inputtext2))
                    {
                        inputtext2 = "0";
                    }

                    switch (action)
                    {
                        case 1:
                            result = Convert.ToDouble(inputtext) + Convert.ToDouble(inputtext2);
                            break;
                        case 2:
                            result = Convert.ToDouble(inputtext) - Convert.ToDouble(inputtext2);
                            break;
                        case 3:
                            result = Convert.ToDouble(inputtext) * Convert.ToDouble(inputtext2);
                            break;
                        case 4:
                            result = Convert.ToDouble(inputtext) / Convert.ToDouble(inputtext2);
                            break;
                    }
                
                    textview.Text = "Result is " + result.ToString();
                    
                };
            
           // Clear textfields and restore Textview original value
            button2.Click += delegate
            {
                textfield1.Text = "";
                textfield2.Text = "";
                textview.Text = "Calculator";
                switch (action)
                {
                    case 1:
                        addBtn.SetBackgroundColor(Color.LightGray);
                        break;
                    case 2:
                        divideBtn.SetBackgroundColor(Color.LightGray);
                        break;
                    case 3:
                        multiplyBtn.SetBackgroundColor(Color.LightGray);
                        break;
                    case 4:
                        subtractBtn.SetBackgroundColor(Color.LightGray);
                        break;
                }
               
                action = 0;

            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        
    }
}