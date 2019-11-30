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
    public class Car
    {
        public string Manufactor { get; set; }
        public string Model { get; set; }
        public int KW { get; set; }
        public int Image { get; set; }
    }
}