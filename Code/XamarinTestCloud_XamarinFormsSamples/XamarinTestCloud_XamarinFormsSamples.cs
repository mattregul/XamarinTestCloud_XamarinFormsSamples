using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace XamarinTestCloud_XamarinFormsSamples
{
	public class App : Application
	{
		ListView ExamplesListview;
		Dictionary<string, Type> ExamplesDictionary;

		public App()
		{

			// Dictionary of the different Examples
			ExamplesDictionary = new Dictionary<string, Type>{
				{"Entry and Editors", typeof(Test_EntryAndEditorPage)},
				{"Pickers (Picker, Date, & Time)", typeof(Test_PickersPage)},

				//{"Buttons", typeof(ComingSoon!)},
				//{"Dropdown/Select Menu", typeof(ComingSoon!)},
				//{"Async Request", typeof(ComingSoon!)},
				//{"Radio & Checkboxes", typeof(ComingSoon!)},
				//{"Colorpicker", typeof(ComingSoon!)},
				//{"Spinner", typeof(ComingSoon!)},
				//{"Agreement", typeof(ComingSoon!)},
				//{"Webview", typeof(ComingSoon!)},
				//{"Embedded Video", typeof(ComingSoon!)},
				//{"Code & Document References", typeof(ComingSoon!)}
				//	... and more?
			};


			// Samples Listview ======================================================
			ExamplesListview = new ListView()
			{
				AutomationId = "ExamplesListview",
			};

			// list out the different examples
			ExamplesListview.ItemsSource = ExamplesDictionary.Keys;

			// Load the selected example when we click on a list item
			ExamplesListview.ItemTapped += async (sender, e) =>
			{
				NavigationPage.SetBackButtonTitle(this, "Back");
				await MainPage.Navigation.PushAsync(NavigateToTest(e.Item.ToString()));
			};
			// ======================================================================




			// Arrange the page content =============================================
			NavigationPage Nav = new NavigationPage(new ContentPage
			{
				Content = new StackLayout
				{
					HorizontalOptions = LayoutOptions.StartAndExpand,
					VerticalOptions = LayoutOptions.StartAndExpand,
					Orientation = StackOrientation.Vertical,
					Children = {
						new Label{Text="Examples:"},
						ExamplesListview
					}
				}
			});
			// ======================================================================

			MainPage = Nav; // Set the MainPage's Page
		}



		/// <summary>
		/// Pass a string of an example page, return a new instance of that page
		/// </summary>
		/// <param name="selectedItem">Selected item as string</param>
		public ContentPage NavigateToTest(string selectedItem)
		{

			foreach (var DictionaryItem in ExamplesDictionary)
			{
				//Debug.WriteLine($"Selected Item {selectedItem} vs DictionaryItem {DictionaryItem.Key}");
				if (selectedItem.ToString() == DictionaryItem.Key)
				{
					Debug.WriteLine($"Found a match - {DictionaryItem.Key}");
					ContentPage newContentPage = (ContentPage)Activator.CreateInstance(DictionaryItem.Value);
					return newContentPage;
				}
			}

			// Something went wrong... lets return something :\
			Debug.WriteLine("Couldn't find a ContentPage match (NavigateToTest()) -- Returning Textbox()");
			return new Test_EntryAndEditorPage();

		}

	}
}

