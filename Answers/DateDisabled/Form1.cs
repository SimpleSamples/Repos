﻿using System;
using System.Windows.Forms;

// DateTimePicker in C# windows Form - Microsoft Q&A
// https://docs.microsoft.com/en-us/answers/questions/518280/datetimepicker-in-c-windows-form.html

namespace DateDisabled
{
    public partial class Form1 : Form, IMessageFilter
    {
        IntPtr dtphwnd = IntPtr.Zero;
        bool CalendarDown = false;

        public Form1()
        {
            InitializeComponent();
            dtphwnd = dateTimePicker1.Handle;
            Application.AddMessageFilter(this);
        }

        public bool PreFilterMessage(ref Message m)
        {
            const int WM_KEYDOWN = 0x0100;
            const int WM_KEYUP = 0x0101;
            if (CalendarDown)
                return false;
            // Does dateTimePicker1 exist?
            if (dtphwnd == IntPtr.Zero)
            {
                return false;
            }
            // Is this message for the dateTimePicker1?
            if (m.HWnd != dtphwnd)
            {
                return false;
            }
            // if key up or key down message then do not process it
            if (m.Msg == WM_KEYDOWN || m.Msg == WM_KEYUP)
                return true;    // stop it from being dispatched
            // All other messages are processed
            return false;
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            CalendarDown = false;
        }

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            CalendarDown = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.RemoveMessageFilter(this);
        }
    }
}
