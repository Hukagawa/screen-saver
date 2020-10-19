using System;
using System.Timers;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Controls;

namespace ScreenSaver.Views
{
    public partial class MainPage : Page, INotifyPropertyChanged
    {
        private System.Timers.Timer aTimer;

        public MainPage()
        {
            InitializeComponent();
            DataContext = this;

            aTimer = new System.Timers.Timer();

            aTimer.Interval = 1000;

            aTimer.Elapsed += showTime;

            aTimer.AutoReset = true;

            aTimer.Enabled = true;

            aTimer.Start();
        }

        private async void showTime(object sender, System.Timers.ElapsedEventArgs e)
        {
            //throw new NotImplementedException();
            DateTime dt = DateTime.Now;
            // 設定：現在時刻
            this.Dispatcher.Invoke((Action)(() =>
            {
                tbDate.Text = dt.ToString("yyyy/MM/dd");
                tbTime.Text = dt.ToString("HH:mm:ss");
            }));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
