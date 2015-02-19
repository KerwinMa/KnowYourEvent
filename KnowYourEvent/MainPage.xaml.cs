using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using KnowYourEvent.Resources;
using TweetSharp;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Facebook;
using System.IO;
using System.Net.Http;


namespace KnowYourEvent
{
    public partial class MainPage : PhoneApplicationPage
    {
        public Action<TwitterSearchResult, TwitterResponse> message;
        public String queryString = null;
        TwitterService service = new TwitterService();
        public MainPage()
        {
            InitializeComponent();
            message = messageResult;
            var service1 = new TwitterService("6V1TS5zCiVwkQxUDODCdHA24a", "hAxb6eEht6TMVxFoXT8aOz65UY4CNCQzrwVV1UvKvJBBE9qO6o");
            service1.AuthenticateWith("3004303633-XafkiZvVq8KTfk0hPusedUwPSQsjiE9c49D4WRZ", "Rjg811qZJnZDaAY9ncdHKxz0ZpuUJNvPtkxinXqv43Qiq");

            service1.Search(new SearchOptions { Q = "#OpenHack2015" }, message);
        }

        private void messageResult(TwitterSearchResult result, TwitterResponse response)
        {
            TwitterStatus[] statusesArray = result.Statuses.ToArray();
            for (int i = 0; i < statusesArray.Length; i++)
            {
                string name = statusesArray[i].Author.ScreenName;
                string imageurl = statusesArray[i].Author.ProfileImageUrl;
                string text = statusesArray[i].Text;
                System.Console.WriteLine(name);
                System.Console.WriteLine(text);
                System.Console.WriteLine(result.ToString());
                
            }
        }


        private void getEventDetails(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage2.xaml", UriKind.Relative));

        }

        private void getLiveFeed(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage1.xaml?queryString="+query.Text, UriKind.Relative));
        }
        

    }
}