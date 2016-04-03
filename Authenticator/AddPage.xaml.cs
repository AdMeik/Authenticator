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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Authenticator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPage : Page
    {
        private MainPage mainPage;
        private Frame contentFrame;

        public AddPage()
        {
            InitializeComponent();

            CheckForCamera();
        }

        private async void CheckForCamera()
        {
            var devices = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(Windows.Devices.Enumeration.DeviceClass.VideoCapture);

            if (devices.Count > 1)
            {
                CommandBar.Visibility = Visibility.Visible;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mainPage = (MainPage)((object[])e.Parameter)[0];
            contentFrame = (Frame)((object[])e.Parameter)[1];
        }

        private void Scan_Click(object sender, RoutedEventArgs e)
        {
            mainPage.Navigate(typeof(ScanPage), contentFrame);
        }
    }
}
