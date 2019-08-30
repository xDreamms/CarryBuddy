using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace CBtest
{
    class LeagueVersion
    {
        public static string LoLVer;
        public static string LoLHFVer;

        public static void GetVersion()
        {
            using (WebClient webClient = new System.Net.WebClient())
            {
                WebClient n = new WebClient();
                var json = n.DownloadString("https://carrybuddy.net/test.json");
                string valueOriginal = Convert.ToString(json);
                var JSONObj = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(valueOriginal);

                string LVER = JSONObj["LeagueVersion"];
                string LHFVER = JSONObj["LeagueHFVersion"];
                LoLVer = LVER;
                LoLHFVer = LHFVER;
                
               
                
            }
        }
    }
}

