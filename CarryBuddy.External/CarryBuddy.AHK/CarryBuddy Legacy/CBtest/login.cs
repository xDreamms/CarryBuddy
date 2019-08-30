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
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;


namespace CBtest
{
     
 
    

    public partial class login : MetroFramework.Forms.MetroForm
    {
       public static string primG;

        public login()
        {
            InitializeComponent();
            loginbtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#00aedb");
            loginbtn.ForeColor = Color.White;
            var main = AppDomain.CurrentDomain.BaseDirectory;
            string scfolder = main + @"\scripts";
            if (!Directory.Exists(scfolder))
                {
                    Directory.CreateDirectory(scfolder);
                }

            CBUpdate.CheckUpdate();
            SubCheck.GetUTCTime();
            SubCheck.GetCBTime();


        }


        async public void loginbtn_Click( object sender, EventArgs e)
        {
            string user;
            if(uname.Text.Length == 0 || password.Text.Length == 0)
            {
                if (uname.Text.Length == 0)
                {
                   error.Text  = "Please Enter the username.";
                    return;
                }
                if(password.Text.Length == 0)
                {
                    error.Text = "Please Enter the password.";
                    return;
                }
                
            }
            if(uname.Text.Length == 0 && password.Text.Length == 0)
            {
               error.Text = "Please Enter the username and password.";
                return;
            }

            error.Text = "Checking for matching account credential";

         //Get the member from the api
          using (var httpClient = new HttpClient())
          {
                

              var response = await httpClient.GetAsync("[REDACTED]" + uname.Text + "[REDACTED]");
                
              response.EnsureSuccessStatusCode();
              string content = await response.Content.ReadAsStringAsync();

              api pl = JsonConvert.DeserializeObject<api>(content);


              if(pl.results.Count == 0)
                {
                    error.Text = "No member found.";
                    return;
                }

                user = uname.Text;
                primG = pl.results[0].PrimaryGroup.name;
              //MessageBox.Show(pl.results[0].PrimaryGroup.name);
              //MessageBox.Show(content);
            }




            //Get the password hash from the Database
            string pwd = null;
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "[REDACTED]";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
                string query = "[REDACTED]" + uname.Text + "'";
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
            orignalpass = password.Text;
            //Check the hashed password with the original password
            using (var httpClient = new HttpClient())
            {


                var response = await httpClient.GetAsync("[REDACTED]" + pwd + "[REDACTED]" + orignalpass);

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
                if(pcheck.verify == "Correct Password")
                {
                   
          

                    if(primG == "Members" && SubCheck.ENB == "True")
                    {
                        //If CB open time is lower than the actual time, ignore and load loader
                        if(Convert.ToInt32(SubCheck.CBUT) < Convert.ToInt32(SubCheck.OUT))
                        {
                            loader lod2 = new loader();
                            lod2.welcome = "Welcome back, " + user + "!";
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

                    if(primG == "Members" && SubCheck.ENB == "False")
                    {
                        loader lod1 = new loader();
                        lod1.welcome = "Welcome back, " + user + "!";
                        lod1.Show();
                        this.Hide();
                        return;
                    }

                    loader lod = new loader();
                    lod.welcome = "Welcome back, " + user + "!";
                    lod.Show();
                    this.Hide();
                    return;

                }
                
           
            }






        }

        private void forgotpwd_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://carrybuddy.net/index.php?/lostpassword/");
        }

        private void createacc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://carrybuddy.net/index.php?/register/"); 
        }

        private void loginbtn_MouseHover(object sender, EventArgs e)
        {
            loginbtn.ForeColor = Color.White;
            loginbtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#00aedb");
        }

        private void loginbtn_MouseLeave(object sender, EventArgs e)
        {
            loginbtn.ForeColor = Color.White;
            loginbtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#00aedb");
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




}
