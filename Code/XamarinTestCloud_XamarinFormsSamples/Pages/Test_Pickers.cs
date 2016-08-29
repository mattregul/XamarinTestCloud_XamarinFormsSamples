using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinTestCloud_XamarinFormsSamples
{
	
	public class Test_PickersPage : ContentPage
	{

		public Test_PickersPage()
		{
			
			// Implicit Styles ======================================================
			//	https://developer.xamarin.com/guides/xamarin-forms/user-interface/styles/
			//	https://developer.xamarin.com/guides/xamarin-forms/user-interface/styles/implicit/
			//	https://developer.xamarin.com/api/type/Xamarin.Forms.Style
			Style labelStyle = new Style(typeof(Label))
			{
				Setters = {
				new Setter { Property = Label.HeightRequestProperty, Value = 25 },
				new Setter { Property = Label.VerticalTextAlignmentProperty, Value = TextAlignment.End },
			}
			};

			Resources = new ResourceDictionary();
			Resources.Add(labelStyle);
			// ======================================================================




			// Picker ===============================================================
			//	https://developer.xamarin.com/api/type/Xamarin.Forms.Picker/
			Picker picker1 = new Picker
			{
				AutomationId = "picker1",
				Title = "Color",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			// Dictionary of some colors
			Dictionary<string, Color> ColorList = new Dictionary<string, Color>
			{
				{ "Aqua", Color.Aqua }, { "Black", Color.Black }, { "Blue", Color.Blue },
				{ "Fuchsia", Color.Fuchsia }, { "Gray", Color.Gray }, { "Green", Color.Green },
				{ "Lime", Color.Lime }, { "Maroon", Color.Maroon }, { "Navy", Color.Navy },
				{ "Olive", Color.Olive }, { "Purple", Color.Purple }, { "Red", Color.Red },
				{ "Silver", Color.Silver }, { "Teal", Color.Teal }, { "Yellow", Color.Yellow }
			};

			// Add the colors to the Picker
			foreach (string colorName in ColorList.Keys)
			{
				picker1.Items.Add(colorName);
			}

			// Create BoxView for displaying the selected Color
			BoxView boxView = new BoxView
			{
				BackgroundColor = Color.White,
				WidthRequest = 40,
				HeightRequest = 40,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			// On Picker Selection, update the box's color
			picker1.SelectedIndexChanged += (sender, args) =>
			{
				if (picker1.SelectedIndex == -1)
					boxView.Color = Color.White;
				else
					boxView.Color = ColorList[picker1.Items[picker1.SelectedIndex]];
			};

			picker1.SelectedIndex = 0; // Now that our SelectedIndexChanged() has been defined, lets tell the picker to default to the first color

			// Add the picker and the boxview to a Horizontal StackLayout, it looks nicer :)
			StackLayout pickerLayout = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Children = {
					picker1,
					boxView
				}
			};
			// ======================================================================

		


			// Date Picker ==========================================================
			//	https://developer.xamarin.com/api/type/Xamarin.Forms.DatePicker/
			DatePicker datepicker1 = new DatePicker
			{
				AutomationId = "datepicker1",
				Format = "D",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			// ======================================================================




			// Time Picker ==========================================================
			//	https://developer.xamarin.com/api/type/Xamarin.Forms.TimePicker/
			TimePicker timepicker1 = new TimePicker
			{
				AutomationId = "timepicker1",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			// ======================================================================



			if (Device.OS == TargetPlatform.iOS)
				BackgroundColor = Color.FromHex("eee"); // So we can see the elements better ¯\_(ツ)_/¯



			// Arrange the page content =============================================
			Content = new ScrollView
			{
				Content = new StackLayout
				{
					Orientation = StackOrientation.Vertical,
					VerticalOptions = LayoutOptions.Start,
					Padding = new Thickness(6),
					Children = {
						new Label{Text = "Pickers", FontAttributes = FontAttributes.Bold},

						new Label{Text = "Picker", TextColor = Color.Blue},
						pickerLayout,

						new Label{Text = "Date Picker", TextColor = Color.Blue},
						datepicker1,

						new Label{Text = "Time Picker", TextColor = Color.Blue},
						timepicker1,
					}
				}
			};
			// ======================================================================

		}

	}
}


