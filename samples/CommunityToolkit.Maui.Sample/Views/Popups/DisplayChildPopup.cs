using CommunityToolkit.Maui.Views;

namespace CommunityToolkit.Maui.Sample;

public class DisplayChildPopup : Popup
{
	public DisplayChildPopup(Page rootPage)
		: this(rootPage, 0)
	{
		//Size = popupSize;
		//Color = Colors.Transparent;
	}

	internal DisplayChildPopup(Page rootPage, int v)
	{
		var lbl = new Label()
		{
			Text = $"Child level: {v}",
			FontSize = 16,
			HorizontalOptions = LayoutOptions.Center,
			Margin = new Thickness(0, 10, 0, 14),
		};

		var layout = new VerticalStackLayout();

		var btn = new Button
		{
			Text = "one child more"
		};

		btn.Clicked += (sender, args) =>
		{
			var popupB = new DisplayChildPopup(rootPage, ++v);
			rootPage.ShowPopupAsync<DisplayChildPopup>(popupB);
		};

		layout.Children.Add(lbl);
		layout.Children.Add(btn);

		Content = new Frame
		{
			CornerRadius = 25,
			HeightRequest = 300,
			WidthRequest = 200,
			Content = layout
		};
	}
}