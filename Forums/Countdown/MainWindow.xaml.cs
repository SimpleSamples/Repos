using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

// This sure does not work. NextStep is being incremented extraneously and we
// get the Done message twice.

namespace Countdown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer CountdownTimer;
        double NextStep = 4000;
        DateTimeOffset StartWhen, StopWhen;

        public MainWindow()
        {
            InitializeComponent();
            CountdownTimer = new System.Timers.Timer();
            CountdownTimer.AutoReset = false;
            StartWhen = DateTimeOffset.UtcNow;
            StopWhen = StartWhen.AddMilliseconds(10000);
            MessageBlock.Text = $"Starting: {StartWhen.ToString("m:s.FFF")} Ending: {StopWhen.ToString("m:s.FFF")}\r\n";
            CountdownTimer.Elapsed += new ElapsedEventHandler(CountdownTimer_Elapsed);
            CountdownTimer.Interval = 1000;       // one second
            CountdownTimer.Enabled = true;
        }

        private void CountdownTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string st = e.SignalTime.ToString("m:s.FFF");
            AppendMessage(sender, e, $"Begin at {st}");
            CountdownTimer.Enabled = false;
            if (DateTimeOffset.UtcNow > StopWhen)
            {
                AppendMessage(sender, e, "Done");
                return;
            }
            try
            {
                NextStep += 4000;
                DateTimeOffset ElapseNext = StartWhen.AddMilliseconds(NextStep);
                TimeSpan difference = ElapseNext - DateTimeOffset.UtcNow;
                CountdownTimer.Enabled = false;
                CountdownTimer.Interval = NextStep - difference.TotalMilliseconds;
                string Message = $"NextStep:{NextStep} ElapseNext:{ElapseNext.ToString("m:s.FFF")} difference: {difference} Interval:{CountdownTimer.Interval}";
                System.Diagnostics.Debug.WriteLine(Message);
                AppendMessage(sender, e, Message);
                CountdownTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                AppendMessage(sender, e, $"Error: {ex.Message}");
            }
        }

        private void AppendMessage(object sender, ElapsedEventArgs e, string Message)
        {
            if (MessageBlock.Dispatcher.CheckAccess())
            {
                MessageBlock.Text += Message + "\r\n";
            }
            else
            {
                MessageBlock.Dispatcher.Invoke(DispatcherPriority.Normal,
                    new EventHandler<ElapsedEventArgs>(CountdownTimer_Elapsed),
                    sender, new object[] { e });
            }
        }
    }
}
