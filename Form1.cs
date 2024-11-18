using System;
using System.Drawing;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace SmartReplace
{
    public partial class Form1 : Form
    {
        static public string YOUTUBE = "https://www.youtube.com/watch?v=";
        static public string TUBEREADER = "https://tubereader.me/videos/";
        public Form1()
        {
            InitializeComponent();
            this.ContextMenuStrip = contextMenuStrip1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSource.Clear();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    string txt1 = txtSource.Text.Trim();
                    if (checkBox1.Checked)
                        txt1 = txt1.Split('?')[0];
                    txtResult.Text = txt1.Replace(TUBEREADER, YOUTUBE);
                    txtResult_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void txtResult_Click(object sender, EventArgs e)
        {
            try
            {
                txtResult.SelectAll();
                if (!String.IsNullOrEmpty(txtResult.Text))
                {
                    Clipboard.SetText(txtResult.Text.Trim());
                    PopupNotifier popup = new PopupNotifier();
                    popup.TitleText = "Copy to clipboard";
                    popup.ContentText = "Copied to clipboard successful!";
                    popup.BodyColor = Color.LightGreen;
                    popup.AnimationDuration = 500;
                    popup.Popup(); // show
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnFromClipboard_Click(object sender, EventArgs e)

        {
            try
            {
                txtSource.Text = Clipboard.GetText();
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Copy from clipboard";
                popup.ContentText = "Pasted from clipboard successful!";
                popup.BodyColor = Color.LightYellow;
                popup.AnimationDuration = 500;
                popup.Popup(); // show
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void onTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = !onTopToolStripMenuItem.Checked;
            onTopToolStripMenuItem.Checked = !onTopToolStripMenuItem.Checked;
        }
    }
}
