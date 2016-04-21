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
    public sealed partial class RegPage : Page
    {
        public RegPage()
        {
            this.InitializeComponent();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            FileLoader c = new FileLoader(@"assets/users.json");
            getData();
            c.writeUserData();
            this.Frame.Navigate(typeof(RegPage2));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        public void getData()
        {
            UserContainer.addUser(new User(FirstnameBox.Text, LastnameBox.Text, AddressBox.Text, LocationBox.Text));
        }
    }
}
