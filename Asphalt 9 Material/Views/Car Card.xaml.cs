using Asphalt_9_Materials.UI.Helpers;
using System.Windows;
using System.Windows.Controls;


namespace Asphalt_9_Materials.UI.Views
{
    /// <summary>
    /// Interaction logic for Car_Card.xaml
    /// </summary>
    public partial class CarCard : UserControl
    {

        /// <summary>
        /// As long as this whole capturing stuff related to UI and ViewModel should not be knowing about the 
        /// Views as violation of MVVM pattern then we do these UI things in UI.
        /// </summary>

        public CarCard()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var statsControl = CarStatsUserControl;

            ReArrangeControlProperties(ref statsControl, 2170, 1840,
                                       1840, ScrollBarVisibility.Hidden);

            var element = statsControl.ContentStack as UIElement;

            var filePath = ControlCapture.SaveDialog(CarName.Text);

            ControlCapture.ControlScreenshot(element, filePath);

            ReArrangeControlProperties(ref statsControl, 835, 475,
                                       475, ScrollBarVisibility.Visible);

        }

        private void ReArrangeControlProperties(ref CarStats statsControl, double stackPanelHeight,
                                                double gridHeight, double scrollViewerHeight,
                                                ScrollBarVisibility scrollBarVisibility)
        {
            statsControl.ContentStack.Height = stackPanelHeight;
            statsControl.MainGrid.Height = gridHeight;
            statsControl.StatsScrollViewer.Height = scrollViewerHeight;
            statsControl.StatsScrollViewer.VerticalScrollBarVisibility = scrollBarVisibility;
        }



    }
}
