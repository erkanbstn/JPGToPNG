using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace JPG_To_PNG_Kodlar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OPF.ShowDialog();
            FBD.ShowDialog();
            Image bmpImageToConvert = Image.FromFile(OPF.FileName);
            Image bmpNewImage = new Bitmap(bmpImageToConvert.Width,
                                           bmpImageToConvert.Height);
            Graphics gfxNewImage = Graphics.FromImage(bmpNewImage);
            gfxNewImage.DrawImage(bmpImageToConvert,
                                  new Rectangle(0, 0, bmpNewImage.Width,
                                                bmpNewImage.Height),
                                  0, 0,
                                  bmpImageToConvert.
                                  Width, bmpImageToConvert.Height,
                                  GraphicsUnit.Pixel);
            gfxNewImage.Dispose();
            bmpImageToConvert.Dispose();
            bmpNewImage.Save(FBD.SelectedPath + "\\Resim.png", ImageFormat.Png);

            XtraMessageBox.Show("JPG Dosyası PNG Dosyasına Başarıyla Dönüştürüldü..!", "GeoTex Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
