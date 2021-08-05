using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EnumWindows
{
    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows",
            ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool EnumDesktopWindows(IntPtr hDesktop,
            EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

        private delegate bool EnumDelegate(IntPtr hWnd, IntPtr lParam);

        public static SortedSet<uint> EnumWindows()
        {
            var ProcessList = new SortedSet<uint>();
            EnumDelegate callBackFn = new EnumDelegate(EnumProc);
            GCHandle handle1 = GCHandle.Alloc(ProcessList);
            EnumDesktopWindows(IntPtr.Zero, callBackFn, (IntPtr)handle1);
            return ProcessList;
        }

        public static bool EnumProc(IntPtr hwnd, IntPtr lparam)
        {
            uint processId = 0;
            GCHandle handle2 = (GCHandle)lparam;
            GetWindowThreadProcessId(hwnd, out processId);
            SortedSet<uint> ProcessList = (handle2.Target as SortedSet<uint>);
            if (!ProcessList.Contains(processId))
                ProcessList.Add(processId);
            return true;
        }

        static void Main(string[] args)
        {
            SortedSet<uint> ProcessList = EnumWindows();
            foreach (uint processId in ProcessList)
            {
                Process ownerProcess = Process.GetProcessById((int)processId);
                Console.WriteLine(ownerProcess.ProcessName);
            }
        }
    }
}
