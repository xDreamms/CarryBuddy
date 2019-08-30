using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace CarryBuddy.Loader.Modules
{
    class Startup
    {
        /// <summary>
        /// Show Splash Function
        /// </summary>
        public void ShowSplash()
        {
            if(Properties.Settings.Default.SplashScreen == true)
            {
                Thread t = new Thread(new ThreadStart(Splash));
                t.Start();
                Thread.Sleep(5000);
                t.Abort();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Generate Splash Application Function
        /// </summary>
        public void Splash()
        {
            Application.Run(new ViewModels.Splash());
        }
    }
}
