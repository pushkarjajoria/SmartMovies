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
    public partial class Confirmed : PhoneApplicationPage
    {
        public Confirmed()
        {
            InitializeComponent();
            confirmationCodeTextBox.Text = globalVars.confirmationCode;
            seatNumTextBox.Text = globalVars.seatNum;
            movieNameTextBox.Text = globalVars.ticketsList.Last.Value.MovieName;
        }
    }
}