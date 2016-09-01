using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XamarinTestCloud_XamarinFormsSamples
{
	public class Test_ButtonsPage : ContentPage
	{
		// Dictionary of some colors
		Dictionary<string, Color> ColorList = new Dictionary<string, Color>
		{
			{ "Aqua", Color.Aqua }, /*{ "Black", Color.Black },*/ { "Blue", Color.Blue },
			{ "Fuchsia", Color.Fuchsia }, { "Gray", Color.Gray }, { "Green", Color.Green },
			{ "Lime", Color.Lime }, { "Maroon", Color.Maroon }, /*{ "Navy", Color.Navy },*/
			{ "Olive", Color.Olive }, { "Purple", Color.Purple }, { "Red", Color.Red },
			{ "Silver", Color.Silver }, { "Teal", Color.Teal }, { "Yellow", Color.Yellow }
		};

		Label label1;
		Label label2;
		Label label3;

		public Test_ButtonsPage()
		{


			// Button ==============================================================
			//	https://developer.xamarin.com/api/type/Xamarin.Forms.Button/
			Button button1 = new Button
			{
				AutomationId = "button1",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Text = "Button 1",
			};

			Button button2 = new Button
			{
				AutomationId = "button2",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Text = "Button 2",
			};

			Button button3 = new Button
			{
				AutomationId = "button3",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Text = "Button 3",
			};

			// On Click, change our boxview's color
			button1.Clicked += (sender, e) => { NewLabelColorAndIncreaseCount(label1); };
			button2.Clicked += (sender, e) => { NewLabelColorAndIncreaseCount(label2); };
			button3.Clicked += (sender, e) => { NewLabelColorAndIncreaseCount(label3); };
			// ======================================================================



			// Labels =============================================================
			//	Create some labels to display our button click counts
			//	https://developer.xamarin.com/api/type/Xamarin.Forms.Label/
			double labelWidth = 40;
			double labelHeight = 40;

			label1 = new Label
			{
				BackgroundColor = Color.White,
				WidthRequest = labelWidth,
				HeightRequest = labelHeight,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Text = "0",
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center
			};

			label2 = new Label
			{
				BackgroundColor = Color.White,
				WidthRequest = labelWidth,
				HeightRequest = labelHeight,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Text = "0",
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center
			};

			label3 = new Label
			{
				BackgroundColor = Color.White,
				WidthRequest = labelWidth,
				HeightRequest = labelHeight,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Text = "0",
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center
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
						new Label{Text = "Buttons", FontAttributes = FontAttributes.Bold},

						new StackLayout
						{
							Orientation = StackOrientation.Horizontal,
							Children = {
								button1,
								label1
							}
						},

						new StackLayout
						{
							Orientation = StackOrientation.Horizontal,
							Children = {
								button2,
								label2
							}
						},

						new StackLayout
						{
							Orientation = StackOrientation.Horizontal,
							Children = {
								button3,
								label3
							}
						},

					}
				}
			};
			// ======================================================================

		}


		/// <summary>
		/// Change the color of our label, and also increase it's counter
		/// </summary>
		/// <param name="label">Label</param>
		public void NewLabelColorAndIncreaseCount(Label label) // Not the best name :)
		{
			Random rnd = new Random();
			// Pick a number between 0 and our ColorList.Count, grab a color at that index location, assign the color to our label
			label.BackgroundColor = ColorList.Values.ElementAt(rnd.Next(0, ColorList.Count));

			// Grab the current label's text, convert it into an Int, Add 1, Turn it back into a string ¯\_(ツ)_/¯
			try
			{
				label.Text = (Int32.Parse(label.Text) + 1).ToString();
			}
			catch (Exception ex)
			{
				label.Text = "0"; // Did you overflow the int?? (2,147,483,648 clicks?!?!) Start over!  ;)
			}
		}
	}
}


