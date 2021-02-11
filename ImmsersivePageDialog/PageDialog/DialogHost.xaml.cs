using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ImmsersivePageDialog.PageDialog
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DialogHost : Page, INotifyPropertyChanged
    {
        #region "DependpencyProperty and Variables"
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool isShowingPage;
        public bool IsShowingPage
        {
            get
            {
                return isShowingPage;
            }
            set
            {
                isShowingPage = value;
                OnPropertyChanged();
            }
        }

        private bool canGoBack;
        public bool CanGoBack
        {
            get
            {
                return canGoBack;
            }
            set
            {
                canGoBack = value;
                OnPropertyChanged();
            }
        }

        private string webViewTitleText;
        public string WebViewTitleText
        {
            get
            {
                return webViewTitleText;
            }
            set
            {
                webViewTitleText = value;
                OnPropertyChanged();
            }
        }

        public bool AllowSoftClose
        {
            get { return (bool)GetValue(AllowSoftCloseProperty); }
            set { SetValue(AllowSoftCloseProperty, value); this.OnPropertyChanged(); }
        }

        // Using a DependencyProperty as the backing store for AllowSoftClose.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllowSoftCloseProperty =
            DependencyProperty.Register("AllowSoftClose", typeof(bool), typeof(DialogHost), new PropertyMetadata(0));

        #endregion

        Frame frame;
        MainPage page;


        public DialogHost()
        {
            IsShowingPage = false;
            CanGoBack = false;
            WebViewTitleText = string.Empty;
            this.DataContext = this;
            this.InitializeComponent();
        }

        public async void Navigate(Type page)
        {
            IsShowingPage = true;
            rootGrid.Visibility = Visibility.Visible;
            contentFrame.Visibility = Visibility.Visible;
            contentFrame.Navigate(page, null, new SuppressNavigationTransitionInfo());
            //await Task.Delay(150);
            ContentHost.Visibility = Visibility.Visible;
        }

        public async void Navigate(Uri url)
        {
            IsShowingPage = false;
            rootGrid.Visibility = Visibility.Visible;
            webView.Visibility = Visibility.Visible;
            webView.Navigate(url);
            //await Task.Delay(150);
            ContentHost.Visibility = Visibility.Visible;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsShowingPage == true)
            {
                page.CloseDialog();
            }
            else
            {
                if (webView.CanGoBack)
                {
                    webView.GoBack();
                }
                else
                {
                    page.CloseDialog();
                }
            }
        }

        private void backgroundBorder_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (AllowSoftClose == true)
            {
                page.CloseDialog();
            }
        }

        public void closeDialog()
        {
            ContentHost.Visibility = Visibility.Collapsed;
            rootGrid.Visibility = Visibility.Collapsed;
            webView.Visibility = Visibility.Collapsed;
            contentFrame.Visibility = Visibility.Collapsed;
        }

        private void webView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            CanGoBack = webView.CanGoBack;
            WebViewTitleText = webView.DocumentTitle;
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            webView.Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            frame = (Frame)Window.Current.Content;
            page = (MainPage)frame.Content;
        }
    }
}
