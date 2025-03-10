﻿using CommunityToolkit.Maui.Sample.ViewModels.Converters;

namespace CommunityToolkit.Maui.Sample.Pages.Converters;

public partial class ItemTappedEventArgsConverterPage : BasePage<ItemTappedEventArgsConverterViewModel>
{
	public ItemTappedEventArgsConverterPage(IDeviceInfo deviceInfo, ItemTappedEventArgsConverterViewModel itemTappedEventArgsViewModel)
		: base(deviceInfo, itemTappedEventArgsViewModel)
	{
		InitializeComponent();
	}
}