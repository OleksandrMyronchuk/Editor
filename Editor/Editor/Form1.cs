using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Editor
{
    public partial class Form1 : Form
    {

        public string currentPath;

        public Form1()
        {
            InitializeComponent();
        }

        private void review_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            OpenFileDialog OPF1 = new OpenFileDialog();
            OPF1.ShowDialog();
            currentPath = OPF1.FileName;

            if (!File.Exists(currentPath))
                return;

            path.Text = currentPath;

            using (FileStream fs = File.Open(currentPath, FileMode.Open, FileAccess.Read))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    richTextBox1.Text += temp.GetString(b);
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (currentPath == null || currentPath == "")
                return;

            using (FileStream fs = File.Open(currentPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes( richTextBox1.Text );
                fs.Write(info, 0, info.Length);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
