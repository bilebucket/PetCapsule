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
    public sealed partial class MyinfoPage : Page
    {

        private bool edit = false;

        public MyinfoPage()
        {
            this.InitializeComponent();
            NameBox.Text = UserContainer.user.Firstname;
            LastnameBox.Text = UserContainer.user.Lastname;
            EmailBox.Text = UserContainer.user.Email;
            AddressBox.Text = UserContainer.user.Address;
            CityBox.Text = UserContainer.user.City;
            UsernameBlock.Text = UserContainer.user.Username;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FrontPage));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
           if (!edit)
            {
                NameBox.IsReadOnly = false;
                LastnameBox.IsReadOnly = false;
                EmailBox.IsReadOnly = false;
                AddressBox.IsReadOnly = false;
                CityBox.IsReadOnly = false;
                edit = true;
                EditButton.Content = "Save";
            } else
            {
                User oldUser = UserContainer.user;

                string newPass = "" + PasswordNewBox.Password;
                if (newPass != "")
                {
                    if(UserContainer.loginCheck(oldUser.Username, oldUser.Password))
                    {
                        oldUser.Password = newPass;
                    }
                }

                User newUser = new User(oldUser.Username, oldUser.Password, EmailBox.Text, NameBox.Text, LastnameBox.Text, AddressBox.Text, CityBox.Text);

                UserContainer.replaceUser(oldUser, newUser);
                FileLoader c = new FileLoader(@"assets/users.json", UserContainer.Users);
                c.writeUserData();
            }
        }
    }
}
