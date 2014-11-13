using System;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;

namespace LSDCExample
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new CarouselPage {
				Children = { new TodoPage {
						Title = "Home"
					},
					new ContentPage {
						Title = "Otra Vista",
						Content = new StackLayout {
							Children = {new Label {
									Text = "Hola!"
								}
							}
						}
					}
				}
			};
		}

		public static MobileServiceClient MobileService = new MobileServiceClient (
			"https://tavohack.azure-mobile.net/",
			"RGaAKTwnzKBpMBtGWCXamzJfhHlTJx55"
			);
	}
}

