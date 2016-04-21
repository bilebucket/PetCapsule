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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PetCapsuleGUI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CagePage : Page
    {
        private int cageID;

        public CagePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = e.Parameter;
            cageID = int.Parse(e.Parameter.ToString());
            HeaderBlock.Text = "Capsule #" + (cageID + 1);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CapsulesPage));
        }

        private void TemperatureButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TemperaturePage), cageID);
        }

        private void HumidityButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HumidityPage), cageID);
        }

        private void VideoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VideoPage), cageID);
        }

        private void StatusButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StatusPage), cageID);
        }
    }
}
