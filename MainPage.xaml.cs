using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.Diagnostics;
using SmartMovies.Resources;
using Microsoft.Phone.Net.NetworkInformation;
using Windows.Networking.Proximity;

namespace SmartMovies
{
    public static class globalVars
    {
        public static string Uname = "";
        public static int ticketIdforNfc = 0;
        public static string serverIP = "192.168.173.1";
        public static string confirmationCode = "";
        public static string seatNum = "";
        public static LinkedList<Items> ticketsList = new LinkedList<Items>();
    }
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            ProximityDevice device = ProximityDevice.GetDefault();
            if(device==null)
            {
                MessageBox.Show("Turn on your NFC");
                Application.Current.Terminate();
            }
            
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://"+globalVars.serverIP+"/mini/index.php?username=" + username.Text + "&password=" + pwd.Password;
            WebClient wc = new WebClient();
            wc.DownloadStringAsync(
               new Uri(url));
            wc.DownloadStringCompleted +=
               new DownloadStringCompletedEventHandler(
                 wc_DownloadStringCompleted);

        }

        void wc_DownloadStringCompleted(object sender,
           DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("ERROR, Make sure you are connected to internet");
                return;
            }
            //Debug.WriteLine(e.Result);

           if (e.Result.Contains("Login successfully"))
            {
                globalVars.Uname = username.Text;
               NavigationService.Navigate(new Uri("/loggedIn.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("LogIn Failed - Bad Username or Password");
            }
        }

        private void writeTag_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/writeTag.xaml", UriKind.Relative));
        }




        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}