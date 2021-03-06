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
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI.Animations;
using System.Numerics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ImmsersivePageDialog
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public void Navigate(Type page)
        {
            background.Scale = new Vector3(1.05f, 1.05f, 1.05f);
            dialogHost.Navigate(page);
        }

        public void Navigate(Uri url)
        {
            background.Scale = new Vector3(1.05f, 1.05f, 1.05f);
            dialogHost.Navigate(url);
        }

        public void CloseDialog()
        {
            background.Scale = new Vector3(1, 1, 1);
            dialogHost.closeDialog();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(ControlPage), null);
        }
    }
}
