using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
namespace CarryBuddy.Loader.Modules
{
    
    class Injector
    {
        /// <summary>
        /// Script Inject Function
        /// </summary>
        /// <param name="DLLName">Name of the DLL, excluding the path to the file</param>
        public void Inject(string DLLName)
        {
            System.IntPtr TargetProcessHandle;
            int TargetBufferSize;
            String pszLibFileRemote;
            int pfnStartAddr;
            
            

            Process[] TargetProcess = Process.GetProcessesByName("League of Legends");
            if (TargetProcess.Length == 0)
            {
                MessageBox.Show("League of Legends is not running.");
                return;
            }
            TargetProcessHandle = RefDLL.OpenProcess(0x1F0FFF, false, TargetProcess[0].Id);
            pszLibFileRemote = Application.StartupPath + ("\\Scripts\\"+ DLLName);
            pfnStartAddr = RefDLL.GetProcAddress(RefDLL.GetModuleHandle("Kernel32.dll"), "LoadLibraryA");

            TargetBufferSize = 1 + pszLibFileRemote.Length;

            int Rtn;
            int LoadLibParamAdr;

            LoadLibParamAdr = RefDLL.VirtualAllocEx(TargetProcessHandle, 0, TargetBufferSize, 4096, 4);
            Rtn = RefDLL.WriteProcessMemory(TargetProcessHandle, LoadLibParamAdr, pszLibFileRemote, TargetBufferSize, 0);
            RefDLL.CreateRemoteThread(TargetProcessHandle, 0, 0, pfnStartAddr, LoadLibParamAdr, 0, 0);
            RefDLL.CloseHandle(TargetProcessHandle);
        }
    }

    /// <summary>
    /// Imports native win function calls
    /// </summary>
    class RefDLL
    {
        [DllImport("kernel32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int ReadProcessMemory(int hProcess, int lpBaseAddress, string lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

        [DllImport("kernel32", EntryPoint = "LoadLibraryA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int LoadLibrary(string lpLibFileName);

        [DllImport("kernel32.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int WriteProcessMemory(IntPtr hProcess, int lpBaseAddress, string lpBuffer, int nSize, int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int VirtualAllocEx(IntPtr hProcess, int lpAddress, int dwSize, int flAllocationType, int flProtect);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int GetProcAddress(int hModule, string procName);

        [DllImport("kernel32.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, int lpThreadAttributes, int dwStackSize, int lpStartAddress, int lpParameter, int dwCreationFlags, int lpThreadId);

        [DllImport("kernel32", EntryPoint = "GetModuleHandleA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(int processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32", EntryPoint = "CloseHandle")]
        public static extern int CloseHandle(System.IntPtr hObject);

        [DllImport("user32", EntryPoint = "GetModuleHandleA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
    }
}
