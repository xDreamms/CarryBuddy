using System;
using System.Diagnostics;
using System.Threading;

namespace CarryBuddy.SDK.Utilities
{
    public class System
    {
        /// <summary>
        /// Searches a window with the title <paramref name="WindowTitle"/> in
        /// all running processes.
        /// </summary>
        /// 
        /// <param name="WindowTitle">Title of the window to search.</param>
        /// 
        /// <returns>
        /// <code>IntPtr.Zero</code> if the window is not found.
        /// Otherwise, returns the window handle.
        /// </returns>

        public static IntPtr GetWindowHandleByTitle(string WindowTitle)
        {
            IntPtr handle = IntPtr.Zero;

            foreach (Process process in Process.GetProcesses())
            {
                if (process.MainWindowTitle.Equals(WindowTitle))
                {
                    handle = process.MainWindowHandle;
                    break;
                }
            }

            return handle;
        }

        /// <summary>
        /// Stops the script for <paramref name="ms"/> miliseconds.
        /// </summary>
        /// 
        /// <param name="ms"> Delay in miliseconds.</param>

        public static void Sleep(int ms)
        {
            Thread.Sleep(ms);
        }
    }
}
