using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Networking.Proximity;

namespace SmartMovies
{
    public partial class NFC : PhoneApplicationPage
    {
        public void DispatchInvoke(Action a)
        {
        #if SILVERLIGHT
            if (Dispatcher == null)
                a();
            else
                Dispatcher.BeginInvoke(a);
            #else
		if ((Dispatcher != null) && (!Dispatcher.HasThreadAccess))
		    {
			    Dispatcher.InvokeAsync(
				    		Windows.UI.Core.CoreDispatcherPriority.Normal, 
		    				(obj, invokedArgs) => { a(); }, 
			    			this, 
		       				null
		    	);
	
		    }
		    else
		    	a();
         #endif
        }
        ProximityDevice device = ProximityDevice.GetDefault();
        public NFC()
        {
            InitializeComponent();
            long subscribedMessageId = device.SubscribeForMessage("Windows.mySubType", messageReceivedHandler);
            if (device == null)
            {
                MessageBox.Show("Your phone has no NFC or NFC is disabled");
                Application.Current.Terminate();
            }

        }

        private void messageReceivedHandler(ProximityDevice device, ProximityMessage message)
        {
            string address = message.DataAsString;
            contactServer(address);
        }
        void contactServer(string messageAsString)
        {
            string url3 = messageAsString + globalVars.ticketIdforNfc;
            WebClient wc3 = new WebClient();
            wc3.DownloadStringAsync(
               new Uri(url3));
            wc3.DownloadStringCompleted +=
               new DownloadStringCompletedEventHandler(
                 wc_DownloadStringCompleted3);
        }
        void wc_DownloadStringCompleted3(object sender,
           DownloadStringCompletedEventArgs e)
        {
            //Debug.WriteLine(e.Result);

            if (e.Error != null)
            {
                MessageBox.Show("ERROR, Make sure you are connected to internet");
                return;
            }

            if (e.Result.Contains("RECIEVED"))
            {
                string[] output = e.Result.Split('|');
                DispatchInvoke(() =>
                {
                    //your operations go here
                    globalVars.confirmationCode = output[0];
                    globalVars.seatNum = output[1];
                    NavigationService.Navigate(new Uri("/Confirmed.xaml", UriKind.Relative));
                }
                );
            }
            else
            {
                DispatchInvoke(() =>
                {
                    //your operations go here
                    MessageBox.Show("Auth Failed");
                }
                );
            }
        }
    }
}