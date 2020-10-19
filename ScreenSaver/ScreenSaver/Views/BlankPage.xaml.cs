﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace ScreenSaver.Views
{
    public partial class BlankPage : Page, INotifyPropertyChanged
    {
        public BlankPage()
        {
            InitializeComponent();
            DataContext = this;
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
