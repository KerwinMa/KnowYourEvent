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
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace KnowYourEvent
{
    public partial class LiveFeedPage : PhoneApplicationPage
    {
            
            public Action<TwitterSearchResult, TwitterResponse> message;
            public String json = null;
            public String query = "";
            List<TwiterItem> item = new List<TwiterItem>();
            public Boolean ispopulated = false;
          

        public LiveFeedPage()
        {
            InitializeComponent();
            getLiveFeed();
            List<String> speakers = new List<string>();
            speakers.Add("Brad Anderson");
            speakers.Add("Julie Larson-Green");
            speakers.Add("Gurdeep Singh Pall");
            speakers.Add("Dave Campbell");
            
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

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (NavigationContext.QueryString.TryGetValue("queryString", out query))
            {
                //query = +query;
            }

        }


        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox1.ItemsSource = item;

        }
    }
    
}