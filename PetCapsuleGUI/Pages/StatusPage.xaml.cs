using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class StatusPage : Page
    {
        private int cageID;
        Random rand = new Random();
        bool tempStatus, humiStatus;
        SolidColorBrush ok = new SolidColorBrush(Color.FromArgb(255, 18, 200, 27));
        SolidColorBrush alert = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));

        public StatusPage()
        {
            this.InitializeComponent();
            tempStatus = rand.Next(1, 3) == 1 ? true : false;
            humiStatus = rand.Next(1, 3) == 1 ? true : false;
            setButtonColors();
        }

        private void setButtonColors()
        {
            TemperatureButton.Background = tempStatus == true ? ok : alert;
            HumidityButton.Background = humiStatus == true ? ok : alert;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = e.Parameter;
            cageID = int.Parse(e.Parameter.ToString());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CagePage), cageID);
        }

        private void TemperatureButton_Click(object sender, RoutedEventArgs e)
        {
            if (!tempStatus) tempStatus = true;
            setButtonColors();
        }

        private void HumidityButton_Click(object sender, RoutedEventArgs e)
        {
            if (!humiStatus) humiStatus = true;
            setButtonColors();
        }
    }
}
