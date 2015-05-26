using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using FotografApp.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Item Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234232
using FotografApp.Model;

namespace FotografApp.View
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public sealed partial class About : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public About()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            object navigationParameter;
            if (e.PageState != null && e.PageState.ContainsKey("SelectedItem"))
            {
                navigationParameter = e.PageState["SelectedItem"];
            }

            // TODO: Assign a bindable group to this.DefaultViewModel["Group"]
            // TODO: Assign a collection of bindable items to this.DefaultViewModel["Items"]
            // TODO: Assign the selected item to this.flipView.SelectedItem
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void OmAtAbout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }

        private void KontaktAtAbout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Contact));
        }

        private void BestilAtAbout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Order));
        }

        private void PortrætAtAbout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Gallery));
        }

        private void NaturAtAbout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Gallery));
        }

        private void ArkitekturAtAbout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Gallery));
        }

        private void BryllupAtAbout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Gallery));
        }

        private void KreativtAtAbout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Gallery));
        }

        private void ExitAppAtAbout(object sender, RoutedEventArgs e)
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