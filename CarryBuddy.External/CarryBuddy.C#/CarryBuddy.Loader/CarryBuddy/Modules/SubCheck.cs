using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace CarryBuddy.Modules
{
    class SubCheck
    {

        public static string OUT { get; set; }
        public static string CBUT { get; set; }
        public static string ENB { get; set; }
        async public static void GetUTCTime()
        {

            using (var httpClient = new HttpClient())
            {
                var response1 = await httpClient.GetAsync("http://worldtimeapi.org/api/timezone/Etc/UTC");

                response1.EnsureSuccessStatusCode();
                string content1 = await response1.Content.ReadAsStringAsync();

                res1 resu = JsonConvert.DeserializeObject<res1>(content1);

                OUT = resu.unixtime;

            }
        }


        async public static void GetCBTime()
        {

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("REDACTED");

                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();

                resCB resuCB = JsonConvert.DeserializeObject<resCB>(content);

                CBUT = resuCB.Unix;
                ENB = resuCB.Enabled;



            }
        }

    }


    class res1
    {
        public string week_number { get; set; }
        public string utc_offset { get; set; }
        public string unixtime { get; set; }
    }

    class resCB
    {
        public string Enabled { get; set; }
        public string Unix { get; set; }
    }
}

