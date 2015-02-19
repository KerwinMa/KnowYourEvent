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
    public partial class PivotPage1 : PhoneApplicationPage
    {
        public Action<TwitterSearchResult, TwitterResponse> message;
        public String json = null;
        public String query = "";
        List<TwiterItem> item = new List<TwiterItem>();
        List<TwiterItem> item1 = new List<TwiterItem>();
        public Boolean ispopulated = false;
        public PivotPage1()
        {
            InitializeComponent();
            
            getLiveFeed();
            getFaceBookFeed();
        }

        private void getFaceBookFeed()
        {
            item1.Add(new TwiterItem()
                    {
                        UserName = "USC Viterbi School of Engineering",
                        Message = "Next week (1/30 – 1/31), Microsoft Careers will be hosting its annual USC vs UCLA hackathon event at their offices in DTLA. Registration is currently open for all students, so sign up now! ‪#‎OpenHack2015‬",
                        ImageSource = "https://scontent-b-sea.xx.fbcdn.net/hphotos-xfa1/v/t1.0-9/483514_10152269866165648_1030594378_n.jpg?oh=03a18b190a68b50def78ba76d80ada23&oe=556C48BD"

                    });
            listBox2.ItemsSource = item1;
                }
        
        private void getLiveFeed()
        {
            message = messageResult;
            twitterFunctions();
        }

        private void twitterFunctions()
        {

            var service1 = new TwitterService("6V1TS5zCiVwkQxUDODCdHA24a", "hAxb6eEht6TMVxFoXT8aOz65UY4CNCQzrwVV1UvKvJBBE9qO6o");
            service1.AuthenticateWith("3004303633-XafkiZvVq8KTfk0hPusedUwPSQsjiE9c49D4WRZ", "Rjg811qZJnZDaAY9ncdHKxz0ZpuUJNvPtkxinXqv43Qiq");
            TwitterService service = new TwitterService();
            service1.Search(new SearchOptions { Q = "#Openhack2015" }, message);

        }

        private void messageResult(TwitterSearchResult result, TwitterResponse response)
        {
            if (result != null)
            {
                json = result.ToString();
                TwitterStatus[] statusesArray = result.Statuses.ToArray();
                for (int i = 0; i < statusesArray.Length; i++)
                {

                    item.Add(new TwiterItem()
                    {
                        Message = statusesArray[i].Text,
                        UserName = statusesArray[i].Author.ScreenName,
                        ImageSource = statusesArray[i].Author.ProfileImageUrl

                    });
                }

                Dispatcher.BeginInvoke(() =>
                {
                    listBox1.ItemsSource = item;
                });


            }

        }
        private void Pivot_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}