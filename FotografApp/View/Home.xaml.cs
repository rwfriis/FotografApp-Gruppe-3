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
using FotografApp.Model;

namespace FotografApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
        }

        private void OmAtHome(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (About));
        }

        private void KontaktAtHome(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (Contact));
        }

        private void BestilAtHome(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Order));
        }

        private void PortrætAtHome(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Gallery));
        }

        private void NaturAtHome(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Gallery));
        }

        private void ArkitekturAHome(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Gallery));
        }

        private void BryllupAtHome(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Gallery));
        }

        private void KreativtAtHome(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Gallery));
        }

        private void ExitAppAtHome(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void RegisterButton(object sender, RoutedEventArgs e)
        {
            Register.ValidateRegistration(NavnSource.Text, PasswordSource.Password, CPasswordSource.Password, E_mailSource.Text, TelefonSource.Text);
        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            Login.LoginAsUser(LEmailSource.Text, LPasswordSource.Password);
        }
    }
}