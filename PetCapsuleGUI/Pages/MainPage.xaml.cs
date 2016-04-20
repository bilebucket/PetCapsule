﻿using System;
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
using PetCapsuleGUI.Logic;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PetCapsuleGUI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();


            User u = new User("testi", "pass", "testi@jotain.com", "Matti", "Meikalainen", "Meikalaisensaijufds", "Turku");
               

            UserContainer uc = new UserContainer(u);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string u = UsernameBox.Text;
            string p = PasswordBox.Password;

            if (UserContainer.user.Username == u && UserContainer.user.Password == p)
            {
                this.Frame.Navigate(typeof(FrontPage));
            }

        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegPage));
        }

        private void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.ForgotpasswordPage));
        }
    }
}
