using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ImmsersivePageDialog.PageDialog
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContentDialog : Page, INotifyPropertyChanged
    {
        private string primaryButtonText;
        public string PrimaryButtonText
        {
            get { return primaryButtonText; }
            set { primaryButtonText = value; OnPropertyChanged(); }
        }
        private string secondaryButtonText;
        public string SecondaryButtonText
        {
            get { return secondaryButtonText; }
            set { secondaryButtonText = value; OnPropertyChanged(); }
        }
        private string closeButtonText;
        public string CloseButtonText
        {
            get { return closeButtonText; }
            set { closeButtonText = value; OnPropertyChanged(); }
        }
        private ContentDialogResult result;

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }
        private string content;
        public string NotificationContent
        {
            get { return content; }
            set { content = value; OnPropertyChanged(); }
        }

        public ContentDialog()
        {
            this.InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
