using System;
using System.Collections.Generic;
using Xamarin.Forms;
using List.Config;

namespace List
{
    public partial class BasketPage : ContentPage
    {
        public BasketPage(string bI)
        {
            InitializeComponent();
            bInfo.Text = bI;
        }
    }
}