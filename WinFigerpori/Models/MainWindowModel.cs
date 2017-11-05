using System.ComponentModel;

namespace WinFigerpori.Models
{
    internal class MainWindowModel : INotifyPropertyChanged
    {
        private string _imagePath;

        public string ImagePath
        {
            get { return _imagePath; }
            set {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public MainWindowModel()
        {
            ImagePath = System.AppDomain.CurrentDomain.BaseDirectory +  @"\test_image.jpg";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
