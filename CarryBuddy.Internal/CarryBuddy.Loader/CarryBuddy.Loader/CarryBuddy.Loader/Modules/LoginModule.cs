using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptSharp;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CarryBuddy.Loader.Modules
{
    class LoginModule
    {
        public static string UserName;
        public static string PrimaryGroup;
        public static string UserPFP;
        public static bool IfUserExist = false;
        public static bool IfPasswordisTrue = false;
        public static bool IfLoginWasSuccessful = false;

       
        /// <summary>
        /// Checks the password for user
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        async public void PasswordChecker(string UserName, string Password)
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync("REDACTED" + UserName + "REDACTED" + Password);

                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();

                PWCK PWCKReturn = JsonConvert.DeserializeObject<PWCK>(content);


                if (PWCKReturn.success == "false")
                {
                    LoginModule.IfPasswordisTrue = false;
                    return;
                }

                LoginModule.IfPasswordisTrue = true;
            }
        }

        /// <summary>
        /// Check if User exists on the API and sets user details
        /// </summary>
        /// <param name="UserName"></param>
        async public void SetUserDetails(string UserName)
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync("REDACTED" + UserName + "REDACTED");

                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();

                APIClass APIReturn = JsonConvert.DeserializeObject<APIClass>(content);


                if (APIReturn.results.Count == 0)
                {
                    LoginModule.IfUserExist = false;
                    return;
                }

                LoginModule.IfUserExist = true;
                LoginModule.UserName = UserName;
                LoginModule.PrimaryGroup = APIReturn.results[0].PrimaryGroup.name;
                LoginModule.UserPFP = APIReturn.results[0].photoUrl;
                Properties.Settings.Default.UserIcon = APIReturn.results[0].photoUrl;
                //MessageBox.Show(pl.results[0].PrimaryGroup.name);
                //MessageBox.Show(content);
            }
        }

        /// <summary>
        /// Extend of ResultClass
        /// </summary>
        class SecondaryGroupClass
        {
            public int id { get; set; }
            public string name { get; set; }
            public string formattedname { get; set; }
        }

        /// <summary>
        /// Extend of ResultClass
        /// </summary>
        class PrimaryGroupClass
        {
            public int id { get; set; }
            public string name { get; set; }
            public string formattedName { get; set; }
        }

        /// <summary>
        /// Extend of APIClass, contains user informations
        /// </summary>
        class ResultClass
        {
            public int id { get; set; }
            public string title { get; set; }
            public string timezone { get; set; }
            public string formattedName { get; set; }
            public PrimaryGroupClass PrimaryGroup { get; set; }
            public List<SecondaryGroupClass> SecondaryGroup { get; set; }
            public string email { get; set; }
            public string joined { get; set; }
            public string registrationIpAddress { get; set; }
            public int warningPoints { get; set; }
            public int reputationPoints { get; set; }
            public string photoUrl { get; set; }
        }

        /// <summary>
        /// API page result
        /// </summary>
        class APIClass
        {
            public int page { get; set; }
            public int perPage { get; set; }
            public int totalResults { get; set; }
            public int totalPages { get; set; }
            public int id { get; set; }
            public List<ResultClass> results { get; set; }

        }

        /// <summary>
        /// JSON storage for PasswordChecker function
        /// </summary>
        class PWCK
        {
            public string success { get; set; }
        }
    }
}
