using System;
using System.Threading.Tasks;

namespace LSDCExample
{
	public class TodoPage : Xamarin.Forms.ContentPage
	{
		#region Declarations
		private Xamarin.Forms.ListView itemsView;
		private Microsoft.WindowsAzure.MobileServices.IMobileServiceTable<TodoItem> todoTable;
		#endregion

		async Task Refresh() {
			itemsView.ItemsSource = await todoTable.OrderBy (X => X.Text).Select (X => X.Text).ToListAsync ();
		}

		protected async override void OnAppearing ()
		{
			await Refresh ();
			base.OnAppearing ();
		}

		public TodoPage() {
			todoTable = LSDCExample.App.MobileService.GetTable<TodoItem> ();
			itemsView = new Xamarin.Forms.ListView ();

			var textBox = new Xamarin.Forms.Entry{ HorizontalOptions = Xamarin.Forms.LayoutOptions.FillAndExpand };
			var addButton = new Xamarin.Forms.Button{ Text = "Agregar" };
			var refreshButton = new Xamarin.Forms.Button{ Text = "Refresh" };

			this.Content = new Xamarin.Forms.StackLayout {
				Padding = 20,
				Orientation = Xamarin.Forms.StackOrientation.Vertical,
				Children = {
					new Xamarin.Forms.StackLayout {
						Orientation = Xamarin.Forms.StackOrientation.Horizontal,
						Children = {
							textBox, addButton, refreshButton
						}
					},
					itemsView
				}
			};

			addButton.Clicked += async (object sender, EventArgs e) => {
				await todoTable.InsertAsync(new TodoItem{ Text = textBox.Text, Complete = false});
				await Refresh();
				textBox.Text = string.Empty;
			};

			refreshButton.Clicked += async (object sender, EventArgs e) => {
				refreshButton.IsEnabled = false;
				await Refresh();
				refreshButton.IsEnabled = true;
			};
		}

	}
}

