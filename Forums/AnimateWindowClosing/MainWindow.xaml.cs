using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimateWindowClosing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DoubleAnimation anim = new DoubleAnimation()
        {
            Duration = TimeSpan.FromSeconds(0.5),
            EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseIn }
        };

        //AutoResetEvent done = new AutoResetEvent(false);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderTransform = new ScaleTransform(1, 1, ActualWidth / 2, ActualHeight / 2);
            anim.From = 0;
            RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, anim);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {}

        void onAnimationCompleted(object sender, EventArgs e)
        {
            anim.Completed -= onAnimationCompleted;
            // done.Set();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            anim.Completed += onAnimationCompleted;
            anim.To = 0;
            //RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, anim);
            BeginAnimation(HeightProperty, anim);
            //done.WaitOne();
        }
    }
}
