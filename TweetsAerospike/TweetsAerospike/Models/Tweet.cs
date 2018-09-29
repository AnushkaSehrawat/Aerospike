using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweetsAerospike.Models
{
    public class Tweet
    {
        public string text { get; set; }
        public string favorited { get; set; }

        public string favoriteCount { get; set; }
        public string replyToSN { get; set; }
        public string created { get; set; }

        public string truncated { get; set; }

        public string replyToSID { get; set; }

        public string id { get; set; }
        public string replyToUID { get; set; }

        public string statusSource { get; set; }
        public string screenName { get; set; }

        public string retweetCount { get; set; }

        public string isRetweet { get; set; }

        public string retweeted { get; set; }
        public string timestamp { get; set; }
        public string us_timestamp { get; set; }

        public string date { get; set; }
    }
}