using PetCapsuleGUI.Logic;
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
    public sealed partial class HumidityPage : Page
    {
        Logic.Humidity humi = UserContainer.user.getCages()[0].Humidity;

        public HumidityPage()
        {
            this.InitializeComponent();
            HumidityBox.Text = "" + humi.CurrentHumidity;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CagePage));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            humi.CurrentHumidity = float.Parse(HumidityBox.Text);
            InfoBlock.Text = humi.info;
            UserContainer.user.getCages()[0].Humidity.CurrentHumidity = humi.CurrentHumidity;
        }

        private void PHumidity_Click(object sender, RoutedEventArgs e)
        {
            humi.CurrentHumidity = float.Parse(HumidityBox.Text);
            humi.CurrentHumidity++;
            HumidityBox.Text = "" + humi.CurrentHumidity;
        }

        private void MHumidity_Click(object sender, RoutedEventArgs e)
        {
            humi.CurrentHumidity = float.Parse(HumidityBox.Text);
            humi.CurrentHumidity--;
            HumidityBox.Text = "" + humi.CurrentHumidity;
        }
    }
}
