using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace NyarukoEye_Windows
{
    static public class Screenshot
    {
        static public void saveScreenshot(string filePath, ImageFormat imageFormat)
        {
            int screenW = Screen.PrimaryScreen.Bounds.Width;
            int screenH = Screen.PrimaryScreen.Bounds.Height;
            Bitmap bmp = new Bitmap(screenW, screenH);
            Graphics gra = Graphics.FromImage(bmp);
            gra.CopyFromScreen(new Point(0, 0), new Point(0, 0), bmp.Size);
            bmp.Save(filePath, imageFormat);
            bmp.Dispose();
            gra.Dispose();
        }
    }
}