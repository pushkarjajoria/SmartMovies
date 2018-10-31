using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace SmartMovies
{
    
    public class Items
    {
        public int TicketID {get; set;}
        public int MovieID { get; set; }
        public int NumberOfTickets { get; set; }
        public string Date { get; set; }
        public string ShowTime { get; set; }
        public string MovieName { get; set; }
        public string MovieType { get; set; }
        public string MovieCast { get; set; }
        public string MovieInfo { get; set; }
    }
    public partial class loggedIn : PhoneApplicationPage
    {
        List<string> StringsList;
        Dictionary<string, int> ticketIdAndInfo;
        string ticketID;

        public loggedIn()
        {
            InitializeComponent();
            StringsList = new List<string>();
            string url2 = "http://"+globalVars.serverIP+"/mini/query.php?user="+globalVars.Uname;
            WebClient wc2 = new WebClient();
            wc2.DownloadStringAsync(
               new Uri(url2));
            wc2.DownloadStringCompleted +=
               new DownloadStringCompletedEventHandler(
                 wc2_DownloadStringCompleted);
        }

        void wc2_DownloadStringCompleted(object sender,
        DownloadStringCompletedEventArgs e)
        {
            if(e.Result == null)
            {
                MessageBox.Show("Invalid Result");
                return;
            }
            string queryResult;
            if (e.Result.Length >= 1)
            {
                queryResult = e.Result.Substring(0, e.Result.Length - 1);
                string[] words = queryResult.Split('|');
                string[] ticketInfo;
                ticketIdAndInfo = new Dictionary<string, int>();
                listSelector.ItemsSource = StringsList;
                int ticketNumber = 0;
                Items obj;
                foreach (string word in words)
                {
                    ticketInfo = words[ticketNumber].Split('$');
                    obj = new Items();
                    try
                    {

                        obj.TicketID = Convert.ToInt32(ticketInfo[0]);
                        obj.MovieID = Convert.ToInt32(ticketInfo[1]);
                        obj.NumberOfTickets = Convert.ToInt32(ticketInfo[2]);
                        obj.Date = ticketInfo[3];
                        obj.ShowTime = ticketInfo[4];
                        obj.MovieName = ticketInfo[5];
                        obj.MovieType = ticketInfo[6];
                        obj.MovieCast = ticketInfo[7];
                        obj.MovieInfo = ticketInfo[8];
                        globalVars.ticketsList.AddLast(obj);
                        ticketNumber++;

                        StringsList.Add(obj.MovieName + "(" + obj.MovieType + ")" + " " + obj.ShowTime + " - # of Tickets" + obj.NumberOfTickets);
                        ticketIdAndInfo.Add(obj.MovieName + "(" + obj.MovieType + ")" + " " + obj.ShowTime + " - # of Tickets" + obj.NumberOfTickets, obj.TicketID);



                    }

                    catch
                    {
                        Console.WriteLine("ERROR WHILE POPULATING LINKED LIST");
                    }
                }
            }
        }

        private void listSelector_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            /*string selectedText = (string)listSelector.SelectedItem;
            string tid = ticketIdAndInfo[(string)listSelector.SelectedItem].ToString();

                MessageBox.Show("You tapped on the ticket with ticketID = " + tid);*/
            string selectedText = (string)listSelector.SelectedItem;
            globalVars.ticketIdforNfc = ticketIdAndInfo[selectedText];
            NavigationService.Navigate(new Uri("/NFC.xaml", UriKind.Relative));

        }


    }
}