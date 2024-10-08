﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppTooling
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Dictionary<string, Type> pages = new Dictionary<string, Type>()
        {
            { "home", typeof(HomePage) },
            { "clipboard", typeof(ClipboardPage) },
            { "device", typeof(DevicePage) }
        };

        public MainPage()
        {
            InitializeComponent();
            NavigationViewControl.SelectedItem = NavigationViewControl.MenuItems[0];
            ContentFrame.Navigate(typeof(HomePage), null);
        }

        private void NavigationViewControl_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var navItemTag = args.InvokedItemContainer.Tag.ToString();
            NavViewNavigate(navItemTag, args.RecommendedNavigationTransitionInfo);
        }

        private void NavViewNavigate(string tag, NavigationTransitionInfo transitionInfo)
        {
            Type page = null;

            var item = pages.FirstOrDefault(p => p.Key.Equals(tag));

            page = item.Value;

            var previousNavPageType = ContentFrame.CurrentSourcePageType;

            if (page != null && !Equals(previousNavPageType, page))
            {
                ContentFrame.Navigate(page, null, transitionInfo);
            }
        }
    }
}
