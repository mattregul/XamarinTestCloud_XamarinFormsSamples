using System;

using Xamarin.Forms;

namespace XamarinTestCloud_XamarinFormsSamples
{
	
	public class Test_EntryAndEditorPage : ContentPage
	{
		
		public Test_EntryAndEditorPage()
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




			// Entry ================================================================
			//	https://developer.xamarin.com/api/type/Xamarin.Forms.Entry/
			Entry entry1 = new Entry
			{
				AutomationId = "entry1",
				Text = "Entry 1",
			};

			Entry entry2 = new Entry
			{
				AutomationId = "entry2",
				Text = "Entry 2"
			};

			Entry entry3 = new Entry
			{
				AutomationId = "entry3",
				Text = "Entry 3 - The five boxing wizards jump quickly" //https://en.wikipedia.org/wiki/Pangram
			};
			// ======================================================================




			// Editor ===============================================================
			//	https://developer.xamarin.com/api/type/Xamarin.Forms.Editor/
			double EditorFontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry));
			double EditorHeightRequest = EditorFontSize * 4 + 4;

			Editor editor1 = new Editor
			{
				AutomationId = "editor1",
				Text = "Editor 1\n\tEditor 1\n\t\tEditor 1",
				FontSize = EditorFontSize,
				HeightRequest = EditorHeightRequest,
				BackgroundColor = Color.White
			};


			Editor editor2 = new Editor
			{
				AutomationId = "editor2",
				Text = "Editor 2",
				FontSize = EditorFontSize,
				HeightRequest = EditorHeightRequest,
				BackgroundColor = Color.White
			};

			Editor editor3 = new Editor
			{
				AutomationId = "editor3",
				Text = "The quick brown fox jumps over the lazy dog", //https://en.wikipedia.org/wiki/Pangram
				FontSize = EditorFontSize,
				HeightRequest = EditorHeightRequest,
				BackgroundColor = Color.White
			};
			// ======================================================================



			if (Device.OS == TargetPlatform.iOS)
				BackgroundColor = Color.FromHex("eee"); // So we can see the elements better ¯\_(ツ)_/¯



			// Arrange the page content =============================================
			Content = new ScrollView {
				Content = new StackLayout
				{
					Orientation = StackOrientation.Vertical,
					VerticalOptions = LayoutOptions.Start,
					Padding = new Thickness(6),
					Children = {
						new Label{Text = "Entry & Editors", FontAttributes = FontAttributes.Bold},

						new Label{Text = "Entry #1", TextColor = Color.Blue},
						entry1,

						new Label{Text = "Entry #2", TextColor = Color.Blue},
						entry2,

						new Label{Text = "Entry #3", TextColor = Color.Blue},
						entry3,

						new Label{Text = "Editor #1", TextColor = Color.Blue},
						editor1,

						new Label{Text = "Editor #2", TextColor = Color.Blue},
						editor2,

						new Label{Text = "Editor #3", TextColor = Color.Blue},
						editor3
					}
				}
			};
			// ======================================================================

		}

	}

}


