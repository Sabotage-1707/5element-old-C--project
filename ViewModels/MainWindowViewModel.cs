using GalaSoft.MvvmLight;
using LAB33_KPIAP.Pages;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace LAB33_KPIAP.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        Page Slaider2;
        Image Korzina = new Image();

        private Page currentPage;
        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
            }
        }

        private double frameOpacity;
        public double FrameOpacity
        {
            get { return frameOpacity; }
            set { frameOpacity = value; }
        }

        public MainWindowViewModel()
        {
            Slaider2 = new Slaider2();

            FrameOpacity = 1;

            CurrentPage = Slaider2;
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri($"pack://application:,,,/Images/Korzina.png");
            myBitmapImage.EndInit();

            Korzina.Source = myBitmapImage;
        }

        public async void SlowOpacity(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    FrameOpacity = 1;
                    Thread.Sleep(50);
                }
                CurrentPage = page;
                for (double i = 0.0; i < 1.1; i += 0.1)
                {
                    FrameOpacity = 1;
                    Thread.Sleep(50);
                }
            });
        }
    }
}
