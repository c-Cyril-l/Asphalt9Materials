using Asphalt_9_Materials.UI.Helpers;
using System.Windows.Controls;

namespace Asphalt_9_Materials.UI.Pages.Misc.Comparison
{
    /// <summary>
    /// Interaction logic for ComparePage.xaml
    /// </summary>
    public partial class BlueprintsComparisonPage : UserControl
    {
        public BlueprintsComparisonPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            var filePath = ControlCapture.SaveDialog("Comparing Stats");

            ControlCapture.ControlScreenshot(MaxStatsDataGrid, filePath);


        }


    }
}
