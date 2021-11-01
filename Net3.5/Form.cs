using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void updatePreviewButton_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

            // プレビューに画像表示用のコールバック関数を登録
            pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);

            //プレビューするPrintDocumentを設定
            printPreviewControl.Document = pd;

            // .NET 2 ～ 3.5では、明示的にInvalidatePreview()を呼びます。
            printPreviewControl.InvalidatePreview();
        }

        private void pd_PrintPage(object sender,
            System.Drawing.Printing.PrintPageEventArgs e)
        {
            // プレビューに画像を表示
            using (Image img = Image.FromFile("test.jpg"))
            {
                e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height);
                e.HasMorePages = false;
            }
        }
    }
}
