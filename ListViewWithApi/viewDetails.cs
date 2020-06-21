using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ListViewWithApi
{
    [Activity(Label = "viewDetails")]
    public class viewDetails : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.listViewDetails);
            TextView txtCategory = FindViewById<TextView>(Resource.Id.categoryText);
            TextView txtJoke = FindViewById<TextView>(Resource.Id.jokeText);
         
            string category = Intent.GetStringExtra("category");
            string joke = Intent.GetStringExtra("joke");

            txtCategory.Text = category;
            txtJoke.Text = joke;

        }
    }
}