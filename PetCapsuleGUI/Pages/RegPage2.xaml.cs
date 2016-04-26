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
    public sealed partial class RegPage2 : Page
    {
        public RegPage2()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegPage));
        }

        /* Tarkistetaan, että kaikki kentät on täytetty */
        private bool checkInput()
        {
            return (UsernameBox.Text != "" && PasswordBox.Password != "" && EmailBox.Text != "");
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            if (!checkInput()) return;
            if (PasswordBox.Password == Password2Box.Password) // tarkistetaan, että salasanat täsmäävät
            {
                if (UserContainer.usernameAvailable(UsernameBox.Text) && UserContainer.emailAvailable(EmailBox.Text)) // tarkistetaan, ettei käyttäjätunnus tai sähköposti ole jo käytössä
                {                    
                    if ((bool)TOCBox.IsChecked) // Tarkistetaan, että käyttöehdot (CheckBox) on hyväksytty
                    {
                        FileLoader c = new FileLoader(@"assets/users.json", UserContainer.Users);
                        getData();
                        c.writeUserData();
                        this.Frame.Navigate(typeof(MainPage));
                    }
                    else {
                        // annetaan virheilmoitus
                        ErrorBlock.Text = "Please accept Terms and Conditions";
                    }
                }
                else
                {
                    // annetaan virheilmoitus
                    ErrorBlock.Text = UserContainer.usernameAvailable(UsernameBox.Text) ? "Email is taken" : "Username is taken";
                }
            } else {
                // annetaan virheilmoitus
                ErrorBlock.Text = "Passwords do not match";
            }
        }

        public void getData()
        {
            UserContainer.user.Username = UsernameBox.Text;
            UserContainer.user.Password = PasswordBox.Password;
            UserContainer.user.Email = EmailBox.Text;
        }
    }
}
