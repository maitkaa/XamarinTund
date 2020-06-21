using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;

namespace ListViewWithApi
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    public class HomeScreen : ListActivity
    {
        string[] items;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            items = new string[] { "Any", "Miscellaneous", "Programming", "Dark" };
            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
        }

        async void GetJoke(string category)
        {
            Joke myJoke = new Joke();
      
            string url = "https://sv443.net/jokeapi/v2/joke/" + category + "?type=single";
          
            var handler = new System.Net.Http.HttpClientHandler();
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient(handler);
            string result = await client.GetStringAsync(url);
            myJoke = Newtonsoft.Json.JsonConvert.DeserializeObject<Joke>(result);
           
           Intent listView = new Intent(this,typeof(viewDetails));
            listView.PutExtra("category", category);
            listView.PutExtra("joke", myJoke.joke);
            StartActivity(listView);
        }

        protected override void OnListItemClick(ListView l, Android.Views.View v, int position, long id)
        {
            var t = items[position];
            GetJoke(t) ;
        }
    }
     
    public class Flags
    {
        public bool nsfw { get; set; }
        public bool religious { get; set; }
        public bool political { get; set; }
        public bool racist { get; set; }
        public bool sexist { get; set; }
    }

    public class Joke
    {
        public string category { get; set; }
        public string type { get; set; }
        public string joke { get; set; }
        public Flags flags { get; set; }
        public int id { get; set; }
        public bool error { get; set; }
    }
   
}