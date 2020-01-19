using Asphalt_9_Materials.ViewModel.ViewModels.MainView;
using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace Asphalt_9_Materials.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const string Format = "HH:mm:ss";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainModelView();
            if (Dispatcher != null)
            {
                var timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal,
                    delegate { TimeTb.Text = DateTime.Now.ToString(Format); }, Dispatcher);
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

    }
}
