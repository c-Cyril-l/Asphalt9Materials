using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Asphalt_9_Materials.UI.Helpers
{
    public class ControlCapture
    {

        public static void ControlScreenshot(UIElement element, string filePath)
        {
            var size = element.RenderSize;
            var rtb = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
            element.Measure(size);
            element.Arrange(new Rect(size));
            rtb.Render(element);
            var png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(rtb));
            using (var stm = File.Create(filePath))
            {
                png.Save(stm);
            }
            MessageBox.Show($"Screenshot Taken Successfully... {"\r\n"}{filePath}");
        }

        public static string SaveDialog(string fileName)
        {
            var sfd = new SaveFileDialog()
            {
                Filter = @"Portable Network Graphics (*.png)|*.png",
                FileName = $"{fileName}.png",
                Title = "Save Image As",
                DefaultExt = "Portable Network Graphics (*.png)|*.png",
                OverwritePrompt = true
            };
            return (sfd.ShowDialog() != true) ? string.Empty : sfd.FileName;
        }

    }
}
