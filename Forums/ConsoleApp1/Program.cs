using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern bool SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        const int WM_GETTEXT = 0x000D;
        const int WM_GETTEXTLENGTH = 0x000E;
        const int WM_KEYDOWN = 0x0100;
        const int WM_KEYUP = 0x0101;
        const int VK_DOWN = 0x28;

        static void Main(string[] args)
        {
            //Console.WriteLine(ConsoleApp1.Resource1.TextFile1);
            IntPtr hWnd = (IntPtr)0x120A2C;
            //IntPtr hWnd = (IntPtr)0xD093E;
            Console.WriteLine($"{GetText(hWnd)}");
            Thread.Sleep(2000);
            Console.WriteLine("Now");
            uint lParam = (0x00000001 | (MapVirtualKey(0x30, 0) << 16));
            SendMessage(hWnd, WM_KEYDOWN, (IntPtr)VK_DOWN, (IntPtr)lParam);
            //Thread.Sleep(500);
            //PostMessage(hWnd, WM_KEYUP, (IntPtr)VK_DOWN, (IntPtr)lParam);
            //Console.WriteLine($"{GetText(hWnd)}");
        }

        static public string GetText(IntPtr hWnd)
        {
            Int32 titleSize = SendMessage(hWnd, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero).ToInt32();
            if (titleSize == 0)
                return String.Empty;
            StringBuilder title = new StringBuilder(titleSize + 1);
            SendMessage(hWnd, (int)WM_GETTEXT, (IntPtr)title.Capacity, title);
            return title.ToString();
        }

    }
}
