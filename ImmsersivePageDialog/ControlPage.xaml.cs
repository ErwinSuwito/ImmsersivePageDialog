using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ImmsersivePageDialog
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ControlPage : Page
    {
        Frame frame;
        MainPage page;

        public ControlPage()
        {
            this.InitializeComponent();
            frame = (Frame)Window.Current.Content;
            page = (MainPage)frame.Content;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            page.Navigate(typeof(PageDialog.SettingsPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            page.Navigate(new Uri("https://msn.com/"));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            page.Navigate(typeof(ImmsersivePageDialog.PageDialog.FaceRecIntroPage));
        }
    }
}
