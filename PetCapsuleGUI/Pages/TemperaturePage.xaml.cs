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
    public sealed partial class TemperaturePage : Page
    {
        Logic.Temperature temp = UserContainer.user.getCages()[0].Temperature;
        
        public TemperaturePage()
        {            
            this.InitializeComponent();
            TemperatureBox.Text = "" + temp.CurrentTemperature;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CagePage));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            temp.CurrentTemperature = float.Parse(TemperatureBox.Text);
            InfoBlock.Text = temp.info;
            UserContainer.user.getCages()[0].Temperature.CurrentTemperature = temp.CurrentTemperature;
        }

        private void PTemperature_Click(object sender, RoutedEventArgs e)
        {
            temp.CurrentTemperature = float.Parse(TemperatureBox.Text);
            temp.CurrentTemperature++;
            TemperatureBox.Text = "" + temp.CurrentTemperature;
        }

        private void MTemperature_Click(object sender, RoutedEventArgs e)
        {
            temp.CurrentTemperature = float.Parse(TemperatureBox.Text);
            temp.CurrentTemperature--;
            TemperatureBox.Text = "" + temp.CurrentTemperature;
        }
    }
}
