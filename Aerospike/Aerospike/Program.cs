using Aerospike.Client;
using CsvHelper;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerospike
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:/Users/asehrawat/Desktop/2018-01-trump-twitter-wars/data/tweets/tweets1.csv");
            CsvReader cr = new CsvReader(sr);
            IEnumerable<Tweet> record = cr.GetRecords<Tweet>();
            var client = new AerospikeClient("18.235.70.103", 3000);
            string nameSpace = "AirEngine";
            string setName = "Anushka";
            foreach (var row in record)
            {
                    var key = new Key(nameSpace, setName, row.id);
                    client.Put(new WritePolicy(), key, new Bin[]
                    {
                        new Bin("text", row.text),
                        new Bin("favorited", row.favorited),
                        new Bin("replyToSN", row.replyToSN),
                        new Bin("created", row.created),
                        new Bin("truncated", row.truncated),
                        new Bin("replyToSID", row.replyToSID),
                        new Bin("id", row.id),
                        new Bin("replyToUID", row.replyToUID),
                        new Bin("StatusSource", row.statusSource),
                        new Bin("screenName", row.screenName),
                        new Bin("retweetCount", row.retweetCount),
                        new Bin("isRetweet", row.isRetweet),
                        new Bin("retweeted", row.retweeted),
                        new Bin("screenName", row.screenName),
                        new Bin("timestamp", row.timestamp),
                        new Bin("us_timestamp", row.us_timestamp),
                        new Bin("date", row.date)


                    });
            }
        }
    }
}
