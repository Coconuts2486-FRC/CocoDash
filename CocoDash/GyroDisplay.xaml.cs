using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace CocoDash
{
    /// <summary>
    /// Interaction logic for GyroDisplay.xaml
    /// </summary>
    public partial class GyroDisplay : UserControl
    {
        DispatcherTimer timer;
        public GyroDisplay()
        {
            Theta = 90;
            ThetaChanged += RenderLine;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(delegate (object sender, EventArgs e) 
            {
                Theta += 0;
            });
            timer.Start();
            InitializeComponent();
        }

        public delegate void EventDelegate(double amt);
        public event EventDelegate ThetaChanged;
        private double _Theta;
        public double Theta
        {
            get
            {
                return _Theta * 180 / Math.PI;
            }
            set
            {
                _Theta = value * Math.PI / 180;
                ThetaChanged?.Invoke(value * Math.PI / 180);
            }
        }

        public void RenderLine(double value)
        {
            line.X1 = circle.ActualWidth / 2;
            line.Y1 = circle.ActualHeight / 2;
            line.X2 = Math.Cos(Theta) * (circle.ActualWidth / 2) + (circle.ActualWidth / 2);
            line.Y2 = Math.Sin(Theta) * (circle.ActualHeight / 2) + (circle.ActualHeight / 2);
        }
    }
}
