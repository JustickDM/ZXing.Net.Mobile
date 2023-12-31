﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

using Xamarin.Essentials;

using Xamarin.Forms;

namespace Sample.Forms.Droid
{
	[Activity(Label = "ZXing Forms",
		Icon = "@mipmap/launcher",
		Theme = "@style/MainTheme",
		MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);

			Platform.Init(this, savedInstanceState);
			Xamarin.Forms.Forms.Init(this, savedInstanceState);

			ZXing.Net.Mobile.Forms.Android.Platform.Init();

			LoadApplication(new App());
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
		{
			Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}
	}
}