using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Networking.Proximity;
using Windows.Storage.Streams;

namespace SmartMovies
{
    public partial class writeTag : PhoneApplicationPage
    {
        public writeTag()
        {
            InitializeComponent();
            var dataWriter = new DataWriter() { UnicodeEncoding = UnicodeEncoding.Utf8 };
            dataWriter.WriteString(textToWrite.Text);
            ProximityDevice device = ProximityDevice.GetDefault();

            // Make sure NFC is supported
            if (device != null)
            {
                device.PublishBinaryMessage("Windows:WriteTag.mySubType", dataWriter.DetachBuffer(), messageWrittenHandler);
 
            }
            
        }
        void messageWrittenHandler(ProximityDevice sender, long publishedMessageId)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                MessageBox.Show("The message is written");
            });
        }
    }
}