using Jmu.Global.Resources.Wpf;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WinFigerpori.Parsers;

namespace WinFigerpori.Models
{
    internal class MainWindowModel : INotifyPropertyChanged
    {
        private string _imagePath;
        private Visibility _loadingTextVisibility;

        public string ImagePath
        {
            get { return _imagePath; }
            set {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public Visibility LoadingTextVisibility
        {
            get { return _loadingTextVisibility; }
            set { _loadingTextVisibility = value;
                OnPropertyChanged(nameof(LoadingTextVisibility));
            }
        }

        public ICommand OpenSettings => new RelayCommand(param => OnOpenSettings());

        public ICommand Exit => new RelayCommand(param => OnExit());

        private void OnExit()
        {
            Application.Current.Shutdown();
        }

        private void OnOpenSettings()
        {
            // TODO
        }

        public MainWindowModel()
        {
            UpdateImage();
            LoadingTextVisibility = Visibility.Visible;
        }

        private async void UpdateImage()
        {
            var filename = AppDomain.CurrentDomain.BaseDirectory + @"\test_image.jpg";
            var hsParser = new HsParser { SavePath = filename };
            var result = await hsParser.ParseAsync();

            if (result)
            {
                ImagePath = filename;
                LoadingTextVisibility = Visibility.Hidden;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
