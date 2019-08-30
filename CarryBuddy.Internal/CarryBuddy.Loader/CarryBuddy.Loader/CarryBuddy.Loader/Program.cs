using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarryBuddy.Loader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Modules.Debugger.IsDebuggerOn == true)
            {
                Application.Run(new ViewModels.Main());
                return;
            }

            if (Properties.Settings.Default.Username != string.Empty)
            {
                Modules.UpdateModule.CheckUpdate();
                if(Properties.Settings.Default.SplashScreen == true)
                {
                    Modules.Startup SModule = new Modules.Startup();
                    SModule.ShowSplash();
                    Application.Run(new ViewModels.Main());
                }
                else
                {
                    Application.Run(new ViewModels.Main());
                }
            }
            else
            {
                Modules.UpdateModule.CheckUpdate();
                Application.Run(new ViewModels.Login());
            }
        }
    }
}
