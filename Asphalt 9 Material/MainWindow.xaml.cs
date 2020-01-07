using Asphalt_9_Materials.ViewModel.ViewModels.MainView;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Asphalt_9_Materials.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string Format = "HH:mm:ss";

        private bool _isClosed;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainModelView();
            var timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                TimeTb.Text = DateTime.Now.ToString(Format);

            }, Dispatcher);

        }

        private void MainView_Closing(object sender, CancelEventArgs e)
        {
            if (_isClosed) return;
            WindowCloseAnimate.Begin();
            e.Cancel = true;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void WindowCloseAnimate_Completed(object sender, EventArgs e)
        {
            _isClosed = true;
            System.Windows.Application.Current.Shutdown();
        }
    }
}
