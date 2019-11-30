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

namespace FourthApp
{
    [Activity(Label = "ImageActivity")]
    public class ImageActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.image_activity_layout);

            var image = Intent.GetIntExtra("imageResource", 0);
            var imageView = FindViewById<ImageView>(Resource.Id.imageView1);
            imageView.SetImageResource(image);
            // Create your application here
        }
    }
}