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

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password == Password2Box.Password)
            {
                if (UserContainer.usernameAvailable(UsernameBox.Text) && UserContainer.emailAvailable(EmailBox.Text))
                {                    
                    if ((bool)TOCBox.IsChecked)
                    {
                        FileLoader c = new FileLoader(@"assets/users.json", UserContainer.Users);
                        getData();
                        c.writeUserData();
                        this.Frame.Navigate(typeof(MainPage));
                    }
                    else { ErrorBlock.Text = "Please accept Terms and Conditions"; }
                }
                else
                {
                    ErrorBlock.Text = UserContainer.usernameAvailable(UsernameBox.Text) ? "Email is taken" : "Username is taken";
                }
            } else { ErrorBlock.Text = "Passwords do not match"; }
        }

        public void getData()
        {
            UserContainer.user.Username = UsernameBox.Text;
            UserContainer.user.Password = PasswordBox.Password;
            UserContainer.user.Email = EmailBox.Text;
        }
    }
}
