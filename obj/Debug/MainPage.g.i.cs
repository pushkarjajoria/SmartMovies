﻿#pragma checksum "C:\Users\PJ\documents\visual studio 2013\Projects\SmartMovies\SmartMovies\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BEFCA00BEAD7EA7AAC207A99DE6483E3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace SmartMovies {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox username;
        
        internal System.Windows.Controls.Button login;
        
        internal System.Windows.Controls.Button writeTag;
        
        internal System.Windows.Controls.PasswordBox pwd;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/SmartMovies;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.username = ((System.Windows.Controls.TextBox)(this.FindName("username")));
            this.login = ((System.Windows.Controls.Button)(this.FindName("login")));
            this.writeTag = ((System.Windows.Controls.Button)(this.FindName("writeTag")));
            this.pwd = ((System.Windows.Controls.PasswordBox)(this.FindName("pwd")));
        }
    }
}

