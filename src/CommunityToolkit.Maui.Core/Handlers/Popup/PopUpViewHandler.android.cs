﻿using System;
using CommunityToolkit.Core.Platform;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Handlers;
using AView = Android.Views.View;

namespace CommunityToolkit.Core.Handlers;

public partial class PopupViewHandler : ElementHandler<IPopup, MCTPopup>
{
	internal AView? Container { get; set; }

	/// <summary>
	/// Action that's triggered when the Popup is Dismissed.
	/// </summary>
	/// <param name="handler">An instance of <see cref="PopupViewHandler"/>.</param>
	/// <param name="view">An instance of <see cref="IPopup"/>.</param>
	/// <param name="result">The result that should return from this Popup.</param>
	public static void MapOnDismissed(PopupViewHandler handler, IPopup view, object? result)
	{
		var popup = handler.NativeView;

		if (popup.IsShowing)
		{
			popup.Dismiss();
		}

		handler.DisconnectHandler(popup);
	}

	/// <summary>
	/// Action that's triggered when the Popup is Opened.
	/// </summary>
	/// <param name="handler">An instance of <see cref="PopupViewHandler"/>.</param>
	/// <param name="view">An instance of <see cref="IPopup"/>.</param>
	/// <param name="result">We don't need to provide the result parameter here.</param>
	public static void MapOnOpened(PopupViewHandler handler, IPopup view, object? result)
	{
		handler.NativeView?.Show();
	}

	/// <summary>
	/// Action that's triggered when the Popup is LightDismissed.
	/// </summary>
	/// <param name="handler">An instance of <see cref="PopupViewHandler"/>.</param>
	/// <param name="view">An instance of <see cref="IPopup"/>.</param>
	/// <param name="result">The result that should return from this Popup.</param>
	public static void MapOnLightDismiss(PopupViewHandler handler, IPopup view, object? result)
	{
		if (view.IsLightDismissEnabled)
		{
			view.LightDismiss();
		}
	}

	/// <summary>
	/// Action that's triggered when the Popup <see cref="IPopup.Anchor"/> property changes.
	/// </summary>
	/// <param name="handler">An instance of <see cref="PopupViewHandler"/>.</param>
	/// <param name="view">An instance of <see cref="IPopup"/>.</param>
	public static void MapAnchor(PopupViewHandler handler, IPopup view)
	{
		handler.NativeView?.SetAnchor(view);
	}

	/// <summary>
	/// Action that's triggered when the Popup <see cref="IPopup.IsLightDismissEnabled"/> property changes.
	/// </summary>
	/// <param name="handler">An instance of <see cref="PopupViewHandler"/>.</param>
	/// <param name="view">An instance of <see cref="IPopup"/>.</param>
	public static void MapLightDismiss(PopupViewHandler handler, IPopup view)
	{
		handler.NativeView?.SetLightDismiss(view);
	}

	/// <summary>
	/// Action that's triggered when the Popup <see cref="IPopup.Color"/> property changes.
	/// </summary>
	/// <param name="handler">An instance of <see cref="PopupViewHandler"/>.</param>
	/// <param name="view">An instance of <see cref="IPopup"/>.</param>
	public static void MapColor(PopupViewHandler handler, IPopup view)
	{
		handler.NativeView?.SetColor(view);
	}

	/// <summary>
	/// Action that's triggered when the Popup <see cref="IPopup.Size"/> property changes.
	/// </summary>
	/// <param name="handler">An instance of <see cref="PopupViewHandler"/>.</param>
	/// <param name="view">An instance of <see cref="IPopup"/>.</param>
	public static void MapSize(PopupViewHandler handler, IPopup view)
	{
		handler.NativeView?.SetSize(view, handler.Container);
		handler.NativeView?.SetAnchor(view);
	}

	/// <inheritdoc/>
	protected override MCTPopup CreateNativeElement()
	{
		_ = MauiContext ?? throw new NullReferenceException("MauiContext is null, please check your MauiApplication.");
		_ = MauiContext.Context ?? throw new NullReferenceException("Android Context is null, please check your MauiApplication.");

		return new MCTPopup(MauiContext.Context, MauiContext);
	}

	/// <inheritdoc/>
	protected override void ConnectHandler(MCTPopup nativeView)
	{
		Container = nativeView.SetElement(VirtualView);
	}

	/// <inheritdoc/>
	void OnShowed(object? sender, EventArgs args)
	{
		VirtualView?.OnOpened();
	}

	/// <inheritdoc/>
	protected override void DisconnectHandler(MCTPopup nativeView)
	{
		nativeView.Dispose();
	}
}
