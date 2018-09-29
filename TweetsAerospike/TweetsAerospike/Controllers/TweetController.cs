using Aerospike.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TweetsAerospike.Models;


namespace TweetsAerospike.Controllers
{
    public class TweetController : ApiController
    {
        
       
        public string nameSpace = "AirEngine";
        public string setName = "anushkaS";
        [HttpGet]

        public List<Record> getTweets([FromUri] List<string> ids)
        {
            var client = new AerospikeClient("18.235.70.103", 3000);
          
            Key[] keys = new Key[ids.Count];
            List<Record> records = new List<Record>();

            for (int index = 0; index < ids.Count; index++)
            {
               
                var key = new Key(nameSpace, setName, ids[index]);
                keys[index] = key;
            }


            for (int index = 0; index < ids.Count; index++)
            {
                Record recordObject = client.Get(new WritePolicy(), keys[index]);
                records.Add(recordObject);
            }

            return records;
        }

        [HttpPut]
       // [Route("api/Tweet/update/{id}")]
        public void Update([FromUri]string id, [FromBody] string newValue)
        {
            var client = new AerospikeClient("18.235.70.103", 3000);

            Bin newBin = new Bin("text",newValue);
            var key = new Key(nameSpace,setName,id.ToString());
            client.Put(new WritePolicy(),key,newBin);
        }

        [HttpDelete]

        public void deleteEntry([FromUri] string id)
        {
            var client = new AerospikeClient("18.235.70.103", 3000);
            var key = new Key(nameSpace,setName,id);
            client.Delete(new WritePolicy(),key);
        }



    }
}
