﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ZXing;
using ZXing.Mobile;

namespace Sample.Forms
{
	public partial class ZXingScannerView : ContentPage
	{
		public ZXingScannerView()
		{
			InitializeComponent();

			toOsSettingsButton.Clicked += (o, e) =>
			{
				Xamarin.Essentials.AppInfo.ShowSettingsUI();
			};

			var options = new MobileBarcodeScanningOptions
			{
				PossibleFormats = new[] { BarcodeFormat.QR_CODE }
			};

			scannerView.Options = options;
			scannerView.OnScanResult += (result) =>
				Device.BeginInvokeOnMainThread(() =>
				{
					scannerView.IsScanning = false;

					scannedValueLabel.Text = result?.Text;
				});
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			scannerView.IsScanning = true;
		}

		protected override void OnDisappearing()
		{
			scannerView.IsScanning = false;

			base.OnDisappearing();
		}
	}
}