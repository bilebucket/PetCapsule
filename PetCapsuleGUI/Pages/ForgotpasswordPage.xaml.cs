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
    public sealed partial class ForgotpasswordPage : Page
    {

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public ForgotpasswordPage()
        {
            this.InitializeComponent();
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ResetPassword_Click(object sender, RoutedEventArgs e)
        {
            User user = UserContainer.getUserByEmailAndUsername(UsernameBox.Text, EmailBox.Text);
            if (user != null)
            {
                    string pass = RandomString(8);
                    NewPassword.Text = pass;

                    User oldUser = user;
                    User newUser = new User(user.Username, pass, user.Email, user.Firstname, user.Lastname, user.Address, user.City);

                    UserContainer.replaceUser(oldUser, newUser);
                    FileLoader c = new FileLoader(@"assets/users.json", UserContainer.Users);
                    c.writeUserData();
                    ErrorBlock.Text = "";
            } else {
                ErrorBlock.Text = "Username or email is incorrect";
            }
        }
    }
}
