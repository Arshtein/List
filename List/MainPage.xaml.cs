using System;
using System.Collections.Generic;
using List.Config;
using Xamarin.Forms;

namespace List
{
    public partial class MainPage : ContentPage
    {
        private int ch;
        private string basketItem;
        public List<Data> lData { get; set; }
        public List<sData> sDat = new List<sData>(20);
        public MainPage()
        {
            InitializeComponent();
            lData = new List<Data>
            {
                new Data {num = 1, Content="Какой-то текс", price = "12"},
                new Data {num = 2, Content="Какой-то текс", price = "32"},
                new Data {num = 3, Content="Какой-то текс", price = "44"},
                new Data {num = 4, Content="Какой-то текс", price = "13"},
                new Data {num = 5, Content="Какой-то текс", price = "23"},
                new Data {num = 6, Content="Какой-то текс", price = "4"},
                new Data {num = 7, Content="Какой-то текс", price = "5"},
                new Data {num = 8, Content="Какой-то текс", price = "11"},
                new Data {num = 9, Content="Какой-то текс", price = "14"},
                new Data {num = 10, Content="Какой-то текс", price = "15"},
                new Data {num = 11, Content="Какой-то текс", price = "43"},
                new Data {num = 12, Content="Какой-то текс", price = "55"},
                new Data {num = 13, Content="Какой-то текс", price = "13"},
                new Data {num = 14, Content="Какой-то текс", price = "234"},
                new Data {num = 15, Content="Какой-то текс", price = "1"},
                new Data {num = 16, Content="Какой-то текс", price = "23"},
                new Data {num = 17, Content="Какой-то текс", price = "4"},
                new Data {num = 23, Content="Какой-то текс", price = "4"}
            };
            this.BindingContext = this;
        }
        private void cbCheck(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.IsChecked == true)
            {
                ch++;
                cbInfo.Text = String.Format("Элементов в корзине: {0}",ch.ToString());
                foreach(Data d in lData)
                {
                    if(d.num == cb.TabIndex)
                    {
                        sDat.Add( new sData() { num = d.num, Content = d.Content, price = d.price } );
                    }
                }
                basketItem = null;
                foreach(sData sd in sDat)
                {
                    basketItem += String.Format("{0} {1} {2}\n",sd.num,sd.Content,sd.price);
                }
            }
            else
            {
                ch--;
                cbInfo.Text = String.Format("Элементов в корзине: {0}", ch.ToString());
                basketItem = null;
                foreach(sData sd in sDat.ToArray())
                {
                    if(cb.TabIndex == sd.num)
                    {
                        var sdI = sd;
                        sDat.Remove(sdI);
                    }
                }
                foreach (sData sd in sDat)
                {
                    basketItem += String.Format("{0} {1} {2}\n", sd.num, sd.Content, sd.price);
                }
            }
        }
        private void sItem(object sender , EventArgs e)
        {
            dataList.SelectedItem = null;
        }
        private async void nBtnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BasketPage(basketItem));
        }
    }
}
