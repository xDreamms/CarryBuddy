using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace CarryBuddy.Modules
{
    public partial class login : MetroFramework.Forms.MetroForm
    {
        public static string primG;
        public static string PFP;

        public login()
        {
            InitializeComponent();
            rememberbox.Enabled = false;
            var main = AppDomain.CurrentDomain.BaseDirectory;
            string scfolder = main + @"\scripts";
            if (!Directory.Exists(scfolder))
            {
                Directory.CreateDirectory(scfolder);
            }
            Modules.Update.CheckUpdate();
        }


        async private void loginbtn_Click(object sender, EventArgs e)
        {
            string user;
            if (usernametxt.Text.Length == 0 || passwordtxt.Text.Length == 0)
            {
                if (usernametxt.Text.Length == 0)
                {
                    error.Text = "Please Enter the username.";
                    return;
                }
                if (passwordtxt.Text.Length == 0)
                {
                    error.Text = "Please Enter the password.";
                    return;
                }

            }
            if (usernametxt.Text.Length == 0 && passwordtxt.Text.Length == 0)
            {
                error.Text = "Please Enter the username and password.";
                return;
            }

            error.Text = "Checking for matching account credential";

            //Get the member from the api
            using (var httpClient = new HttpClient())
            {


                var response = await httpClient.GetAsync("REDACTED" + usernametxt.Text + "REDACTED");

                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();

                api pl = JsonConvert.DeserializeObject<api>(content);


                if (pl.results.Count == 0)
                {
                    error.Text = "No member found.";
                    return;
                }

                user = usernametxt.Text;
                primG = pl.results[0].PrimaryGroup.name;
                PFP = pl.results[0].photoUrl;
                //MessageBox.Show(pl.results[0].PrimaryGroup.name);
                //MessageBox.Show(content);
            }




            //Get the password hash from the Database
            string pwd = null;
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "REDACTED";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
                string query = "REDACTED" + usernametxt.Text + "'";
                var cmd = new MySqlCommand(query, cnn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetString(0);
                    pwd = someStringFromColumnZero;
                    //  MessageBox.Show(someStringFromColumnZero);
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                //error.Text = "Could not connect to database." + ex.ToString();
                MessageBox.Show(ex.ToString());
                return;
            }



            string orignalpass = null;
            orignalpass = passwordtxt.Text;
            //Check the hashed password with the original password
            using (var httpClient = new HttpClient())
            {


                var response = await httpClient.GetAsync("REDACTED" + pwd + "REDACTED" + orignalpass);

                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();

                pwdchecker pcheck = JsonConvert.DeserializeObject<pwdchecker>(content);

                /*  TESTING PURPOSE
                MessageBox.Show(pcheck.verify); // Outputs the json object
                MessageBox.Show(content); //Outputs raw JSON
                */


                //If password is incorrect return;
                if (pcheck.verify == "Incorrect Password")
                {
                    error.Text = "Password is incorrect";
                    return;
                }

                //If password is correct open loader
                if (pcheck.verify == "Correct Password")
                {



                    if (primG == "Members" && SubCheck.ENB == "True")
                    {
                        //If CB open time is lower than the actual time, ignore and load loader
                        if (Convert.ToInt32(SubCheck.CBUT) < Convert.ToInt32(SubCheck.OUT))
                        {
                            loader lod2 = new loader();
                            lod2.welcome.Text = "Welcome back, " + user + "!";
                            lod2.Show();
                            this.Hide();
                            return;
                        }

                        //Else, Wait
                        double timestamp = Convert.ToInt32(SubCheck.CBUT);

                        // Format our new DateTime object to start at the UNIX Epoch
                        System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

                        // Add the timestamp (number of seconds since the Epoch) to be converted
                        dateTime = dateTime.AddSeconds(timestamp);

                        MetroFramework.MetroMessageBox.Show(this, "Free users have to wait till, " + dateTime.ToString() + "UTC. If you do not want to wait, please purchase a subscription from our website", "Information");
                        return;
                    }

                    if (primG == "Members" && SubCheck.ENB == "False")
                    {
                        loader lod1 = new loader();
                        lod1.welcome.Text = "Welcome back, " + user + "!";
                        lod1.Show();
                        this.Hide();
                        return;
                    }

                    loader lod = new loader();
                    lod.welcome.Text = "Welcome back, " + user + "!";
                    lod.Show();
                    this.Hide();
                    return;

                }


            }


        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void metroPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }


        class sg
        {

            public int id { get; set; }
            public string name { get; set; }
            public string formattedname { get; set; }


        }

        class pg
        {
            public int id { get; set; }
            public string name { get; set; }
            public string formattedName { get; set; }
        }

        class res
        {
            public int id { get; set; }
            public string title { get; set; }
            public string timezone { get; set; }
            public string formattedName { get; set; }
            public pg PrimaryGroup { get; set; }
            public List<sg> SecondaryGroup { get; set; }
            public string email { get; set; }
            public string joined { get; set; }
            public string registrationIpAddress { get; set; }
            public int warningPoints { get; set; }
            public int reputationPoints { get; set; }
            public string photoUrl { get; set; }




        }



        class api
        {
            public int page { get; set; }
            public int perPage { get; set; }
            public int totalResults { get; set; }
            public int totalPages { get; set; }
            public int id { get; set; }
            public List<res> results { get; set; }

        }


        class pwdchecker
        {
            public string verify { get; set; }


        }






        private void minimisebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://carrybuddy.net/index.php?/register");
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://carrybuddy.net/index.php?/lostpassword/");
        }

        private void error_SizeChanged(object sender, EventArgs e)
        {
           if(error.Text.Length == 40)
            {
                error.Location = new Point(60, 127);
            }

            if (error.Text.Length == 26)
            {
                error.Location =  new Point(90, 127);
            }

            if (error.Text.Length == 39)
            {
                error.Location = new Point(55, 127);
            }

            if (error.Text.Length == 16)
            {
                error.Location = new Point(115, 127);
            }

            if (error.Text.Length == 21)
            {
                error.Location = new Point(110, 127);
            }


        }

       

       
        
    }
}
