using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TweetSharp;

namespace KnowYourEvent
{
    public partial class PivotPage2 : PhoneApplicationPage
    {
        public Action<TwitterSearchResult, TwitterResponse> message;
        public String json = null;
        public String query = "";
        List<TwiterItem> item = new List<TwiterItem>();
        List<TwiterItem> item1 = new List<TwiterItem>();
        public Boolean ispopulated = false;
        public PivotPage2()
        {
            InitializeComponent();

            getLiveFeed();
        }
        private void getLiveFeed()
        {
           
            twitterFunctions();
        }

        private void twitterFunctions()
        {

            item.Add(new TwiterItem()
            {
                Message = "",
                UserName = "Chobby Bang",
                ImageSource = "https://pbs.twimg.com/profile_images/1828394340/image.jpg"

            });



            listBox2.ItemsSource = item;

        }

       

        

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}